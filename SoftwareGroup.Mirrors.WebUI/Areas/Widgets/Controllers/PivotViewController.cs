using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using SoftwareGroup.Mirrors.Common;
using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.DataEntity.Analysis;
using SoftwareGroup.Mirrors.Infra;
using SoftwareGroup.Mirrors.WebUI.Areas.Widgets.Models;
using SoftwareGroup.Mirrors.WebUI.Models.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SoftwareGroup.Mirrors.WebUI.Areas.Widgets.Controllers
{
    public class PivotViewController : Controller
    {        
        public ActionResult Index(int widgetID)
        {
            var widgetRepository = IoC.Resolve<IWidgetRepository>();
            Widget widget = widgetRepository.Get(widgetID);
            PivotViewModel pivotViewModel;            
            pivotViewModel = new PivotViewModel();
            Session["PivotViewModel"] = pivotViewModel;

            ViewBag.DesignMode = false;

            return PartialView("Index",pivotViewModel);
        }
        
        public ActionResult ContentPartial(bool designMode)
        {
            PivotViewModel pivotViewModel = (PivotViewModel)Session["PivotViewModel"];
            ViewBag.DesignMode = designMode;
            return PartialView(pivotViewModel);
        }    

        public ActionResult PivotPartial()
        {
            PivotViewModel pivotViewModel = (PivotViewModel) Session["PivotViewModel"];
            return PartialView(pivotViewModel);
        }
    }

}
