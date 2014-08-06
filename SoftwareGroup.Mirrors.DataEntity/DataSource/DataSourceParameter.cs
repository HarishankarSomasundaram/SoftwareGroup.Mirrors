using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.DataSource
{
    public  class DataSourceParameter
    {
        public int ParameterID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public int SourceID { get; set; }

        public virtual DataSource DataSource { get; set; }
    }
}
