using JDash;
using JDash.Models;
using JDash.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportModel = SoftwareGroup.Mirrors.WebUI.Models.Report;

namespace SoftwareGroup.Mirrors.WebUI.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Info Graphs";
            ViewBag.SubTitle = "Explore";
            IEnumerable<DashboardModel> dashboards = ViewBag.Dashboards = JDashManager.Provider.GetDashboardsOfUser(JDashManager.CurrentUser).Where(d => int.Parse(d.id) > 2141);
            return View();
        }

        public ActionResult MyReports()
        {
            ViewBag.Title = "Info Graphs";
            ViewBag.SubTitle = "MyReports";
            //IEnumerable<DashboardModel> dashboards = ViewBag.Dashboards = JDashManager.Provider.GetDashboardsOfUser(JDashManager.CurrentUser);            
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Info Graphs";
            ViewBag.SubTitle = "Create";
            var model = new ReportModel.DashboardModel()
            {
                LayoutId = 12,
                IsShared = false,
                Group = "Common"
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ReportModel.DashboardModel model)
        {
            if (ModelState.IsValid)
            {
                var newDashboard = new DashboardModel()
                {
                    title = model.Title,
                    layout = LayoutModel.GetPredefinedGridLayout(model.LayoutId.ToString())
                };
                newDashboard.metaData.description = model.Description;
                newDashboard.metaData.group = model.Group;
                newDashboard.UserProperty1 = JsonConvert.SerializeObject(model);
                JDashManager.Provider.CreateDashboard(newDashboard);
                model.Id = newDashboard.id;
                return RedirectToAction("CreateLayout", new { id = model.Id });
            }
            return View(model);
        }

        public ActionResult CreateLayout(string id)
        {
            ViewBag.Title = "Info Graphs";
            ViewBag.SubTitle = "Create";
            IEnumerable<DashletModuleModel> modules;
            try
            {
                //Filter to get only mirrors dashlet modules.
                var query = new DynamicQuery();
                query.filter = new FilterParam();
                query.filter.filters = new List<JDash.Query.Filter>();
                query.filter.filters.Add(new JDash.Query.Filter()
                {
                    field = "metaData.group",
                    op = CompareOperator.eq,
                    value = "Mirrors"
                });
                modules = ViewBag.DashletModules = JDashManager.Provider.SearchDashletModules(query).data;
            }
            catch (Exception exc)
            {
                ViewBag.Exception = exc;
                return View("ConfigDB");
            }

            ViewBag.DashletModuleCategories = modules.Select(x => x.metaData.group).Distinct();
            ViewBag.CurrentDashboard = id;
            ReportModel.DashboardModel model = JsonConvert.DeserializeObject<ReportModel.DashboardModel>(JDashManager.Provider.GetDashboard(id).UserProperty1);
            return View("CreateLayout", model);
        }

        public ActionResult View(int id)
        {
            ViewBag.Title = "Info Graphs";
            ViewBag.SubTitle = "Explore";
            IEnumerable<DashletModuleModel> modules;
            try
            {
                //Filter to get only mirrors dashlet modules.
                var query = new DynamicQuery();
                query.filter = new FilterParam();
                query.filter.filters = new List<JDash.Query.Filter>();
                query.filter.filters.Add(new JDash.Query.Filter()
                {
                    field = "metaData.group",
                    op = CompareOperator.eq,
                    value = "Mirrors"
                });
                modules = ViewBag.DashletModules = JDashManager.Provider.SearchDashletModules(query).data;
            }
            catch (Exception exc)
            {
                ViewBag.Exception = exc;
                return View("ConfigDB");
            }
            ViewBag.DashletModuleCategories = modules.Select(x => x.metaData.group).Distinct();
            ViewBag.CurrentDashboard = id;
            ViewBag.Dashboard = JDashManager.Provider.GetDashboard(id.ToString());
            return View();
        }

    }
}
