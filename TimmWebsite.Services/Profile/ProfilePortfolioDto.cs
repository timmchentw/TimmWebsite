using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimmWebsite.Shared.Enums;

namespace TimmWebsite.Services.Profile
{
    public class ProfilePortfolioDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
        public List<PortfolioTag> Tags { get; set; }
    }
}
