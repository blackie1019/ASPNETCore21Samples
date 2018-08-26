using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc0826.Models;

namespace mvc0826.Controllers
{
    public class HomeController : Controller
    {
        public IAppSettingsTransient A1 { get; }
        public IAppSettingsScoped A2 { get; }
        public IAppSettingsSingleton A3 { get; }

        public HomeController(IAppSettingsTransient a1, IAppSettingsScoped a2, IAppSettingsSingleton a3)
        {
            A1 = a1;
            A2 = a2;
            A3 = a3;
        }
        
        public IActionResult AppSetting()
        {
            ViewBag.TransientName = A1.Name;

            ViewBag.ScopedName = A2.Name;

            ViewBag.SingletonName = A3.Name;
               
            return View();
        }

        
        public IActionResult Index()
        {
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
