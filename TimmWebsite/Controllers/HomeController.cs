using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimmWebsite.Models;
using TimmWebsite.Services;
using TimmWebsite.Services.Profile;

namespace TimmWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IDalSession _dalSession;
        private readonly IProfileService _profileService;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IDalSession dalSession, IProfileService profileService)
        {
            _logger = logger;
            _config = config;
            _dalSession = dalSession;
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            var portfolioDtos = _profileService.GetPortfolio();
            var skillDtos = _profileService.GetSkills();
            var timeLineDtos = _profileService.GetTimeLineItems();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfilePortfolioDto, ProfileViewModel.PortfolioItem>();
                cfg.CreateMap<ProfileSkillDto, ProfileViewModel.SkillItem>();
                cfg.CreateMap<ProfileTimeLineDto, ProfileViewModel.TimeLineItem>();
            });
            var mapper = config.CreateMapper();

            var viewModel = new ProfileViewModel()
            {
                PortfolioItems = mapper.Map<List<ProfileViewModel.PortfolioItem>>(portfolioDtos),
                SkillItems = mapper.Map<List<ProfileViewModel.SkillItem>>(skillDtos),
                TimeLineItems = mapper.Map<List<ProfileViewModel.TimeLineItem>>(timeLineDtos)
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
