using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.DataEntity.Analysis;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Areas.Widgets.Controllers
{
    public class LabelController : Controller
    {
        public ActionResult Index(int widgetID)
        {
            var widgetRepository = IoC.Resolve<IWidgetRepository>();
            Widget widget = widgetRepository.Get(widgetID);
            return PartialView(widget);
        }
    }
}
