using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.DataAccess.Repository;

namespace TimmWebsite.DataAccess.UnitOfWork
{
    public class UnitOfWorkBase : IUnitOfWork
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get; set; }
        private IDbTransaction _transaction { get; set; }
        private IDapperRepository _genericRepo { get; set; }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                }
                return _connection;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public IDapperRepository GenericRepo
        {
            get
            {
                if (_genericRepo == null)
                {
                    _genericRepo = new DapperRepositoryBase(this);
                }
                return _genericRepo;
            }
        }

        public UnitOfWorkBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Begin()
        {
            Reset();
            _transaction = Connection.BeginTransaction();
        }

        public void Save()
        {
            try
            {
                _transaction.Commit();
                _transaction = null;
            }
            catch (Exception ex)
            {
                Reset();
                throw;
            }
        }

        public void Reset()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Reset();
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
