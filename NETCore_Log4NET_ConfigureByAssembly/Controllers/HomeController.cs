using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore_Log4NET_ConfigureByAssembly.Models;
using log4net;

namespace NETCore_Log4NET_ConfigureByAssembly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILog log;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

        [HttpGet("logInfo")]
        public JsonResult WriteLogInfo()
        {
            string info = "This is a info message.";
            log.Info(info);
            return Json("");
        }

        [HttpGet("logError")]
        public JsonResult WriteLogError()
        {
            string info = "This is a error message.";
            log.Error(info);
            return Json("");
        }
    }
}
