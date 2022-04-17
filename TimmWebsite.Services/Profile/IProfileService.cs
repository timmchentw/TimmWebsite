using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimmWebsite.Services.Profile
{
    public interface IProfileService
    {
        List<ProfilePortfolioDto> GetPortfolio();
        List<ProfileSkillDto> GetSkills();
        List<ProfileTimeLineDto> GetTimeLineItems();
    }
}
