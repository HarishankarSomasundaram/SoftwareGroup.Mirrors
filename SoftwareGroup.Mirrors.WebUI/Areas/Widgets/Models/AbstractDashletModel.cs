using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Areas.Widgets.Models
{
    public class AbstractDashletModel
    {
        [Display(Name = "Chart Title")]
        public string SubTitle { get; set; }

        public int DataSourceInstanceId { get; set; }

        [JsonIgnore]
        public string DashletProperties { get; set; }
    }
}