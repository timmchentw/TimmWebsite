using System;
using System.Data;
using System.Data.SqlClient;
using TimmWebsite.DataAccess.Repository;

namespace TimmWebsite.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction{ get; }
        IDapperRepository GenericRepo { get; }

        void Begin();
        void Save();
        void Reset();
    }
}
