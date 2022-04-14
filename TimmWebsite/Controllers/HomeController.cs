using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimmWebsite.Models;
using TimmWebsite.Services;

namespace TimmWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IResumeService _resumeService;

        public HomeController(ILogger<HomeController> logger, IResumeService resumeService)
        {
            _logger = logger;
            _resumeService = resumeService;
        }

        public IActionResult Index()
        {
            var portfolioDtos = _resumeService.GetPortfolio();
            var skillDtos = _resumeService.GetSkills();
            var timeLineDtos = _resumeService.GetTimeLineItems();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ResumePortfolioDto, ResumeViewModel.PortfolioItem>();
                cfg.CreateMap<ResumeSkillDto, ResumeViewModel.SkillItem>();
                cfg.CreateMap<ResumeTimeLineDto, ResumeViewModel.TimeLineItem>();
            });
            var mapper = config.CreateMapper();

            var viewModel = new ResumeViewModel()
            {
                PortfolioItems = mapper.Map<List<ResumeViewModel.PortfolioItem>>(portfolioDtos),
                SkillItems = mapper.Map<List<ResumeViewModel.SkillItem>>(skillDtos),
                TimeLineItems = mapper.Map<List<ResumeViewModel.TimeLineItem>>(timeLineDtos)
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
