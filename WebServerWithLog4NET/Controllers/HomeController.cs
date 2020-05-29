using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebServerWithLog4NET.Models;

namespace WebServerWithLog4NET.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILog log;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            log = LogManager.GetLogger(Startup.repository.Name, typeof(HomeController));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("loginfo")]
        public JsonResult WriteLogInfo()
        {
            string info = "This is a info message.";
            log.Info(info);
            return Json(info);
        }

        [HttpGet("logerror")]
        public JsonResult WriteLogError()
        {
            string info = "This is a error message.";
            log.Error(info);
            return Json(info);
        }
    }
}
