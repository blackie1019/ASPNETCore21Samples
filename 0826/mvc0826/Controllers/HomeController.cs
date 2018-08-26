using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc0826.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace mvc0826.Controllers
{
    public class HomeController : Controller
    {
        public IAppSettingsTransient Transient { get; }
        public IAppSettingsScoped Scoped { get; }
        public IAppSettingsSingleton Singleton { get; }
        public AppSettingsJson ConfigJson { get; }
        public AppSettingsSubJson SubConfigJson { get; }
        public ILogger Logger { get; }

        public HomeController(ILogger<HomeController> logger,IAppSettingsTransient appSettingsTransient, IAppSettingsScoped appSettingsScoped, IAppSettingsSingleton appSettingsSingleton, IOptionsSnapshot<AppSettingsJson> appconfig,IOptionsSnapshot<AppSettingsSubJson> subAppconfig)
        {
            this.Logger = logger;
            
            Transient = appSettingsTransient;
            Scoped = appSettingsScoped;
            Singleton = appSettingsSingleton;
            
            ConfigJson = appconfig.Value;
            SubConfigJson = subAppconfig.Value;
        }
        
        public IActionResult AppSetting()
        {
            ViewBag.TransientName = Transient.Name;

            ViewBag.ScopedName = Scoped.Name;

            ViewBag.SingletonName = Singleton.Name;
               
            return View();
        }
        
        public IActionResult AppSettingJson()
        {
            return Content(ConfigJson.AppName+","+SubConfigJson.Version+","+SubConfigJson.Id);
        }

        public IActionResult GetSession()
        {
            return Content(HttpContext.Session.GetInt32("clicks").ToString());
        }

        public IActionResult Test()
        {
            Logger.LogInformation("Test1");
            Logger.LogDebug("Test2");
            Logger.LogError("Test3");
            Logger.LogCritical("Test4");

            return Content("ok, check console for log");
        }
        
        public IActionResult Index()
        {
            var currentValue = HttpContext.Session.GetInt32("clicks") ?? 0;
            HttpContext.Session.SetInt32("clicks",++currentValue);
            return View();
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
