using SoftwareGroup.Mirrors.DataEntity.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Models.Analysis
{
    public class AnalysisModel
    {
        public string AnalysisName {get;set;}
        public string AnalysisDescription { get; set; }
        public int AnalysisGroupID { get; set; }
        public int LayoutID { get; set; }
       
        public string AnalysisGroupName { get; set; }
    }
}