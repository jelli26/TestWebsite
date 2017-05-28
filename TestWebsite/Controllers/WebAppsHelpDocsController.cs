using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestWebsite.Controllers
{
    public class WebAppsHelpDocsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HowTo_Edit_PATH_And_CLASSPATH()
        {
            ViewData["Message"] = "The HowTo_Edit_PATH_And_CLASSPATH page.";

            return View();
        }

        public IActionResult HowTo_Install_Java_And_MySQLConnector()
        {
            ViewData["Message"] = "The HowTo_Install_Java_And_The_MySQLConnector page.";

            return View();
        }

        public IActionResult HowTo_Check_For_Bad_Softlinks()
        {
            ViewData["Message"] = "The HowTo_CheckForBadSoftlinks page.";

            return View();
        }

        public IActionResult HowTo_Install_Apache_Tomcat()
        {
            ViewData["Message"] = "The HowTo_Install_Apache_Tomcat page.";

            return View();
        }

        public IActionResult HowTo_Get_Started_With_Tomcat()
        {
            ViewData["Message"] = "The HowTo_Get_Started_With_Tomcat page.";

            return View();
        }

        public IActionResult HowTo_Get_Started_With_Tomcat_Servlets()
        {
            ViewData["Message"] = "The HowTo_Get_Started_With_Tomcat_Servlets page.";

            return View();
        }

        public IActionResult HowTo_Install_Apache_PHP_And_MySQL()
        {
            ViewData["Message"] = "The HowTo_Install_Apache_PHP_And_MySQL page.";

            return View();
        }

        public IActionResult HowTo_Run_Apache_At_Startup()
        {
            ViewData["Message"] = "The HowTo_Run_Apache_And_MySQL_At_Startups_And_Set_Up_NoIP page.";

            return View();
        }

        public IActionResult HowTo_SetUp_MySQL_Password_And_Databases()
        {
            ViewData["Message"] = "The HowTo_Set_Up_MySQL_UsersAndPasswords_And_Install_Sakila_DB page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
