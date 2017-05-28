using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestWebsite.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult TestSite()
        {
            ViewData["Message"] = "Your Test Website page.";

            return View();
        }

        public IActionResult WebAppsHelpDocs()
        {
            ViewData["Message"] = "Your Test Website page.";

            return View();
        }

        public IActionResult InstallWolfenstein()
        {
            ViewData["Message"] = "Your How To Install Wolfenstein page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
