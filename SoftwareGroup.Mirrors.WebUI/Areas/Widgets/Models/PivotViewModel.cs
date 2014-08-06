using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Areas.Widgets.Models
{
    public class PivotViewModel
    {
        static string olapCS = "provider=msolap;Data Source= KANAGUSUB" +
                ";initial catalog=\"Adventure Works DW 2008R2\";cube name=\"Adventure Works\"";

        public string OlapConnectionString {
            get {
                return olapCS;
            }
        }

        public string LayoutString { get; set; }
    }
}