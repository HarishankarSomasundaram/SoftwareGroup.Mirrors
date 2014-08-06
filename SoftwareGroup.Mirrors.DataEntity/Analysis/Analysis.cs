using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.Analysis
{
    public class Analysis
    {
        public int AnalysisID { get; set; }
        public int AnalysisGroupID { get; set; }
        public string AnalysisName { get; set; }
        
        public string AnalysisDescription { get; set; }
        public string AnalysisLayoutData { get; set; }
    }
}
