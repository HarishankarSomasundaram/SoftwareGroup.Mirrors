using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Users()
        {
            ViewBag.Title = "Administration";
            ViewBag.SubTitle = "Users";
            return View();
        }

        public ActionResult Permissions()
        {
            ViewBag.Title = "Administration";
            ViewBag.SubTitle = "Permissions";
            return View();
        }
    }
}
