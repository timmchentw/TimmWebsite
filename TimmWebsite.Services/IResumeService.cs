using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimmWebsite.Services
{
    public interface IResumeService
    {
        List<ResumePortfolioDto> GetPortfolio();
        List<ResumeSkillDto> GetSkills();
        List<ResumeTimeLineDto> GetTimeLineItems();
    }
}
