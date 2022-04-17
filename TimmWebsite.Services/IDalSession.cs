using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.DataAccess.UnitOfWork;

namespace TimmWebsite.Services
{
    public interface IDalSession : IDisposable
    {
        UnitOfWorkProfile UnitOfWorkProfile { get; }

        void UseProfileTransaction(Action method);

    }
}
