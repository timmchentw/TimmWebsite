using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.Shared.Enums;

namespace TimmWebsite.Services
{
    public class ResumeSkillDto
    {
        public SkillType Type { get; set; }
        public List<string> Skills { get; set; }
    }
}
