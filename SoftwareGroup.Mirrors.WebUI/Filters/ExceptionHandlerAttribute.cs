using SoftwareGroup.Mirrors.Core;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Web.Mvc;

namespace SoftwareGroup.Mirrors.WebUI.Filters
{
    public class ExceptionHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            try
            {
                var logger = IoC.Resolve<ILogger>();
                logger.LogError(filterContext.Exception);
            } catch { }
            base.OnException(filterContext);
        }
    }
}
