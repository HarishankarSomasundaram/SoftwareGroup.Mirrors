using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Models.Report
{
    public class DashboardModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Layout")]
        public int LayoutId { get; set; }

        [Display(Name = "Group")]
        public string Group { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Shared?")]
        public bool IsShared { get; set; }
    }
}