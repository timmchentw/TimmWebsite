using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.DataAccess.DataModel;
using TimmWebsite.DataAccess.UnitOfWork;

namespace TimmWebsite.DataAccess.Repository
{
    public class ProfilePortfolioRepo : DapperRepositoryBaseCRUD<Profile_Portfolio>
    {
        public ProfilePortfolioRepo(IUnitOfWork unitOfWorkProfile)
            : base(unitOfWorkProfile, nameof(Profile_Portfolio.Seq))
        {
            // Init base Dapper repo constructor
        }

        public new virtual List<Profile_Portfolio> Get(string sql, object parameters = null)
        {
            return base.Get(sql, parameters);
        }

        public new virtual List<Profile_Portfolio> GetAll()
        {
            return base.GetAll();
        }

        public new virtual Profile_Portfolio GetById(string id)
        {
            return base.GetById(id);
        }

        public new virtual void Insert(Profile_Portfolio entity)
        {
            base.Insert(entity);
        }

        public new virtual void Update(Profile_Portfolio entity)
        {
            base.Update(entity);
        }

        public new virtual void Delete(string id)
        {
            base.Delete(id);
        }
    }
}
