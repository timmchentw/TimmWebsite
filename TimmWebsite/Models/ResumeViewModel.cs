using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimmWebsite.Models
{
    public class ResumeViewModel
    {
        public List<PortfolioItem> PortfolioItems { get; set; }
        public List<SkillItem> SkillItems { get; set; }
        public List<TimeLineItem> TimeLineItems { get; set; }

        public class PortfolioItem
        {
            public string Title { get; set; }
            public string Text { get; set; }
            public string ImgUrl { get; set; }
            public List<string> Tags { get; set; }
        }

        public class SkillItem
        {
            public string Type { get; set; }
            public List<string> Skills { get; set; }
        }

        public class TimeLineItem
        {
            public int Year { get; set; }
            public string Month { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
