using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.Analysis
{
    public class WidgetType
    {
        public virtual ICollection<WidgetType> AnalysisWidgetTypes { get; set; }

        public int WidgetTypeID { get; set; }
        public string WidgetTypeName { get; set; }
        public string WidgetTypeData { get; set; }

        public WidgetType()
        {
            this.AnalysisWidgetTypes = new HashSet<WidgetType>();
        }
    }
}
