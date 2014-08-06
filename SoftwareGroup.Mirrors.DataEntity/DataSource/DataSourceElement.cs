using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.DataSource
{
    public  class DataSourceElement
    {
        public int ElementID { get; set; }
        public string ElementName { get; set; }
        public string ElementDataType { get; set; }
        public int SourceID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int SortOrder { get; set; }
        public string ElementType { get; set; }

        public virtual DataSource DataSource { get; set; }
    }
}
