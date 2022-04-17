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
    public class DapperRepositoryBase : IDapperRepository
    {
        protected readonly IUnitOfWork _unitOfWork;

        public DapperRepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual List<T> Get<T>(string sql, object parameters = null, int? timeoutSeconds = null)
        {
            var entities = _unitOfWork.Connection.Query<T>(sql, parameters, _unitOfWork.Transaction, commandTimeout: timeoutSeconds ?? 30);
            return entities.ToList();
        }


        public virtual int Execute(string sql, object parameters = null, int? timeoutSeconds = null)
        {
            int affectedRows = _unitOfWork.Connection.Execute(sql, parameters, _unitOfWork.Transaction, commandTimeout: timeoutSeconds ?? 30);
            return affectedRows;
        }
    }
}
