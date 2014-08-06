using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.DataSource
{
    public  class DataConnection
    {
        public DataConnection()
        {
            this.DataSources = new HashSet<DataSource>();
        }

        public int ConnectionID { get; set; }
        public string ConnectionName { get; set; }
        public int ConnectionTypeID { get; set; }
        public string HostName { get; set; }
        public string AuthenticationType { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string CatalogName { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public System.DateTime CreatedOn { get; set; }

        public virtual DataConnectionType DataConnectionType { get; set; }
        public virtual ICollection<DataSource> DataSources { get; set; }
    }
}
