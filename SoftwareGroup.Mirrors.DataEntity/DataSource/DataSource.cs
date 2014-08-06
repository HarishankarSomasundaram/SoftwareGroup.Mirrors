using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.DataSource
{
    public  class DataSource
    {
        public DataSource()
        {
            this.DataSourceElements = new HashSet<DataSourceElement>();
            this.DataSourceParameters = new HashSet<DataSourceParameter>();
        }

        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public int ConnectionID { get; set; }
        public int SourceTypeID { get; set; }
        public string ObjectName { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual DataConnection DataConnection { get; set; }
        public virtual DataSourceType DataSourceType { get; set; }
        public virtual ICollection<DataSourceElement> DataSourceElements { get; set; }
        public virtual ICollection<DataSourceParameter> DataSourceParameters { get; set; }
    }
}
