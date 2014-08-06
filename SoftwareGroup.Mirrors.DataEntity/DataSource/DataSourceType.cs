using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.DataSource
{
    public  class DataSourceType
    {
        public DataSourceType()
        {
            this.DataSources = new HashSet<DataSource>();
        }

        public int SourceTypeID { get; set; }
        public string SourceTypeName { get; set; }

        public virtual ICollection<DataSource> DataSources { get; set; }
    }
}
