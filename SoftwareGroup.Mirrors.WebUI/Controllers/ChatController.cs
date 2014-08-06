using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            ViewBag.Title = "Communicator";
            ViewBag.SubTitle = "Index";
            return View();
        }
    }
}
