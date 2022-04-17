using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.DataAccess.UnitOfWork;
using TimmWebsite.Shared;

namespace TimmWebsite.Services
{
    public class DalSession : IDalSession
    {
        private readonly IConfiguration _config;
        private UnitOfWorkProfile _unitOfWorkProfile { get; set; }

        public UnitOfWorkProfile UnitOfWorkProfile
        {
            get
            {
                if (_unitOfWorkProfile == null)
                {
                    _unitOfWorkProfile = new UnitOfWorkProfile(_config.GetConnectionString(nameof(ConnectionStrings.Profile)));
                }
                return _unitOfWorkProfile;
            }
        }

        public DalSession(IConfiguration config)
        {
            _config = config;
        }

        public void UseProfileTransaction(Action method)
        {
            try
            {
                _unitOfWorkProfile.Begin();
                method();
                _unitOfWorkProfile.Save();
            }
            catch (Exception ex)
            {
                _unitOfWorkProfile.Reset();
                throw;
            }
        }

        public void Dispose()
        {
            if (_unitOfWorkProfile != null) _unitOfWorkProfile.Dispose();
        }
    }
}
