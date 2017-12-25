using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystemDashBoard.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            ViewBag.Test = COD.FindItem<string>("select top 1 definition from sys.all_sql_modules");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}