using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.SubTitle = "Dashboard";
            return View();
        }        

        public ActionResult Dashboard()
        {
            ViewBag.Title = "Home";
            ViewBag.SubTitle = "Dashboard";
            return View();
        }
    }
}
