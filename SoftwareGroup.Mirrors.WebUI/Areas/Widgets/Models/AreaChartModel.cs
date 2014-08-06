using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Areas.Widgets.Models
{
    public class AreaChartModel : AbstractDashletModel
    {
        [Display(Name = "X Axis Title")]
        public string XAxisTitle { get; set; }

        [Display(Name = "Y Axis Title")]
        public string YAxisTitle { get; set; }
    }
}