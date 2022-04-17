using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.DataAccess.Repository;

namespace TimmWebsite.DataAccess.UnitOfWork
{
    public class UnitOfWorkProfile : UnitOfWorkBase, IUnitOfWork
    {
        private ProfilePortfolioRepo _profilePortfolioRepo { get; set; }


        public ProfilePortfolioRepo ProfilePortfolio
        {
            get
            {
                if (_profilePortfolioRepo == null)
                {
                    _profilePortfolioRepo = new ProfilePortfolioRepo(this);
                }
                return _profilePortfolioRepo;
            }
        }

        public UnitOfWorkProfile(string connectionStringProfile)
            : base(connectionStringProfile)
        {
            // Init base constructor
        }
    }
}
