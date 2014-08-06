using SoftwareGroup.Mirrors.Common;
using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.DataEntity.Analysis;
using SoftwareGroup.Mirrors.Infra;
using SoftwareGroup.Mirrors.Service.Analysis;
using SoftwareGroup.Mirrors.WebUI.Models.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Controllers
{
    public class AnalysisController : Controller
    {
        [HttpGet()]
        public ActionResult NewAnalysis()
        {
            AnalysisModel model = new AnalysisModel();
            ViewBag.AnalysisGroups = IoC.Resolve<IAnalysisGroupRepository>().GetAll();
            return View(model);
        }

        [HttpPost()]
        public ActionResult NewAnalysis(AnalysisModel analysisModel)
        {
            //Create analysis
            int analysisID =0;
            bool IsInserterd = false;
            var analysisRepositoty = IoC.Resolve<IAnalysisRepository>();
            var AnalysisGroupRepository = IoC.Resolve<IAnalysisGroupRepository>();
            if (analysisModel.AnalysisGroupName != null)
            {
                int analysisGroupID = AnalysisGroupRepository.Create(new DataEntity.Analysis.AnalysisGroup { AnalysisGroupName = analysisModel.AnalysisGroupName }
                    );
                if (analysisGroupID != 0)
                {
                    analysisID = analysisRepositoty.Create(
                 new DataEntity.Analysis.Analysis
                 {
                     AnalysisName = analysisModel.AnalysisName,
                     AnalysisGroupID = analysisGroupID,

                     AnalysisDescription = analysisModel.AnalysisDescription,
                     AnalysisLayoutData = "",
                 });
                }
                else
                {
                    AnalysisModel model = new AnalysisModel();
                    ViewBag.AnalysisGroups = IoC.Resolve<IAnalysisGroupRepository>().GetAll();
                    return View(model);
                }
            }
            else
            {
                 analysisID = analysisRepositoty.Create(
              new DataEntity.Analysis.Analysis
              {
                  AnalysisName = analysisModel.AnalysisName,
                  AnalysisGroupID = analysisModel.AnalysisGroupID,

                  AnalysisDescription = analysisModel.AnalysisDescription,
                  AnalysisLayoutData = "",
              });

            }

           


            return RedirectToAction("ViewAnalysis", new { analysisID = analysisID, LayoutID = analysisModel.LayoutID });
        }

        public ActionResult ViewAnalysis(int analysisID, int LayoutID)
        {
            var widgetsRepository = IoC.Resolve<IWidgetRepository>();
            List<Widget> widgets = widgetsRepository.GetWidgets(analysisID);
            ViewBag.Widgets = widgets;

            var analysisRepositoty = IoC.Resolve<IAnalysisRepository>();
            Analysis analysis = analysisRepositoty.Get(analysisID);

            List<WidgetType> widgetTypes = new WidgetTypeService().GetAll();
            ViewBag.WidgetTypes = widgetTypes;

            ViewBag.AnalysisID = analysis.AnalysisID;

            SetZoneLayoutCSS(LayoutID);

            return View();
        }

        public ActionResult AddWidget(int analysisID = 0, int widgetTypeID = 0)
        {
            var analysisRepositoty = IoC.Resolve<IAnalysisRepository>();
            Analysis analysis = analysisRepositoty.Get(analysisID);

            var widgetsRepository = IoC.Resolve<IWidgetRepository>();

            Widget widget = new Widget
            {
                AnalysisID = analysisID,
                WidgetTypeID = widgetTypeID,
                WidgetData = DateTime.Now.ToString(),
                UID = Guid.NewGuid().ToString()
            };
            widget.WidgetID = widgetsRepository.Create(widget);

            return PartialView("WidgetPartial", widget);
        }


        public int DeleteWidget(string widgetUID)
        {
            var widgetsRepository = IoC.Resolve<IWidgetRepository>();
            widgetsRepository.Delete(widgetUID);

            return 0;
        }

        public int SaveWidgetLayout(string widgetUID, int visibleIndex, string ownerZoneUID)
        {
            var widgetLayoutData = new WidgetLayoutData() { VisibleIndex = visibleIndex, OwnerZoneUID = ownerZoneUID };

            var widgetsRepository = IoC.Resolve<IWidgetRepository>();
            Widget widget = widgetsRepository.Get(widgetUID);
            widget.WidgetLayoutData = JsonHelper.JsonSerializer<WidgetLayoutData>(widgetLayoutData);
            widgetsRepository.Update(widget);

            return 0;
        }

        public ActionResult Layout()
        {
            return View();
        }

        private void SetZoneLayoutCSS(int LayoutID)
        {
            switch (LayoutID)
            {
                case 0:
                    ViewBag.DockZone1CSS = "col-md-12";
                    ViewBag.DockZone2CSS = "hiddenDockZone";
                    ViewBag.DockZone3CSS = "hiddenDockZone";
                    ViewBag.DockZone4CSS = "hiddenDockZone";
                    break;
                case 1:
                    ViewBag.DockZone1CSS = "col-md-6";
                    ViewBag.DockZone2CSS = "col-md-6";
                    ViewBag.DockZone3CSS = "hiddenDockZone";
                    ViewBag.DockZone4CSS = "hiddenDockZone";
                    break;
                case 2:
                    ViewBag.DockZone1CSS = "col-md-4";
                    ViewBag.DockZone2CSS = "col-md-4";
                    ViewBag.DockZone3CSS = "col-md-4";
                    ViewBag.DockZone4CSS = "hiddenDockZone";

                    break;
                case 3:
                    ViewBag.DockZone1CSS = "col-md-12";
                    ViewBag.DockZone2CSS = "col-md-6";
                    ViewBag.DockZone3CSS = "col-md-6";
                    ViewBag.DockZone4CSS = "hiddenDockZone";
                    break;
                case 4:
                    ViewBag.DockZone1CSS = "hiddenDockZone";
                    ViewBag.DockZone2CSS = "hiddenDockZone";
                    ViewBag.DockZone3CSS = "hiddenDockZone";
                    ViewBag.DockZone4CSS = "hiddenDockZone";
                    break;
                default:
                    break;
            }
        }
    }
}
