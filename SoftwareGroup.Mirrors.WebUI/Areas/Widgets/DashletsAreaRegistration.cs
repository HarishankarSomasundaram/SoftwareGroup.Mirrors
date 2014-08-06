using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Areas.Widgets
{
    public class WidgetsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Widgets";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Widgets_default",
                "Widgets/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
