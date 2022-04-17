using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimmWebsite.DataAccess.Repository
{
    public interface IDapperRepository
    {
        List<T> Get<T>(string sql, object parameters = null, int? timeoutSeconds = null);
        int Execute(string sql, object parameters = null, int? timeoutSeconds = null);
    }
}
