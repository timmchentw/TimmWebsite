using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.DataAccess.UnitOfWork;
using TimmWebsite.DataAccess.Utils;

namespace TimmWebsite.DataAccess.Repository
{
    public class DapperRepositoryBaseCRUD<T> : DapperRepositoryBase
    {
        protected readonly string _tableName;
        protected readonly string _primaryKeyName;
        protected readonly List<string> _columnNames;
        protected readonly int _timeoutSeconds;
        protected readonly int _bulkCopyBatchSize;

        public DapperRepositoryBaseCRUD(IUnitOfWork unitOfWork, string primaryKeyName, int? timeoutSeconds = null, int? bulkCopyBatchSize = null)
            : base(unitOfWork)
        {
            _primaryKeyName = primaryKeyName;
            _tableName = typeof(T).Name;
            _columnNames = DalUtil.GetColumns<T>(new List<string>() { primaryKeyName });

            _timeoutSeconds = timeoutSeconds ?? 30;
            _bulkCopyBatchSize = bulkCopyBatchSize ?? 3000;
        }

        protected List<T> Get(string sql, object parameters = null)
        {
            return base.Get<T>(sql, parameters, _timeoutSeconds);
        }

        protected List<T> GetAll()
        {
            string sql = $@"
                SELECT *
                FROM {_tableName}";
            var entities = _unitOfWork.Connection.Query<T>(sql, _unitOfWork.Transaction, commandTimeout: _timeoutSeconds);
            return entities.ToList();
        }

        protected T GetById(string id)
        {
            string sql = $@"
                SELECT *
                FROM {_tableName}
                WHERE {_primaryKeyName} = @ID";
            var entity = _unitOfWork.Connection.QueryFirstOrDefault<T>(sql, new { ID = id }, _unitOfWork.Transaction, _timeoutSeconds);
            return entity;
        }

        protected void BulkInsert(List<T> entities)
        {
            using (var bulkCopy = (_unitOfWork.Transaction != null) ?
                            new SqlBulkCopy((SqlConnection)_unitOfWork.Connection, SqlBulkCopyOptions.Default, (SqlTransaction)_unitOfWork.Transaction) :
                            new SqlBulkCopy((SqlConnection)_unitOfWork.Connection))
            {
                bulkCopy.DestinationTableName = _tableName;
                bulkCopy.BatchSize = _bulkCopyBatchSize;
                bulkCopy.BulkCopyTimeout = _timeoutSeconds;

                var dataTable = DalUtil.ConvertToDataTable(entities);
                foreach (DataColumn column in dataTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(column.ColumnName, column.ColumnName));
                }

                bulkCopy.WriteToServer(dataTable);
            }
        }

        protected void Insert(List<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Insert(entity);
            }
        }

        protected void Insert(T entity)
        {
            string sql = $@"
                INSERT INTO {_tableName} ({string.Join(',', _columnNames)})
                VALUES {DalUtil.GetSqlParameterString(_columnNames)}";
            _unitOfWork.Connection.Execute(sql, entity, _unitOfWork.Transaction, _timeoutSeconds);
        }

        protected void Update(List<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Update(entity);
            }
        }

        protected void Update(T entity)
        {
            string sql = $@"
                UPDATE {_tableName}
                SET {DalUtil.GetSqlParameterPairs(_columnNames)}
                WHERE {DalUtil.GetSqlParameterPairs(new List<string>() { _primaryKeyName })}";
            _unitOfWork.Connection.Execute(sql, entity, _unitOfWork.Transaction, _timeoutSeconds);
        }

        protected void Delete(List<string> ids)
        {
            string sql = $@"
                DELETE FROM {_tableName}
                WHERE {_primaryKeyName} in @IDs";
            _unitOfWork.Connection.Execute(sql, new { IDs = ids }, _unitOfWork.Transaction, _timeoutSeconds);
        }

        protected void Delete(string id)
        {
            this.Delete(id);
        }
    }
}
