using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.DataSource
{
    public  class DataConnectionType
    {
        public DataConnectionType()
        {
            this.DataConnections = new HashSet<DataConnection>();
        }

        public int ConnectionTypeID { get; set; }
        public string ConnectionTypeName { get; set; }
        public string ProviderName { get; set; }

        public virtual ICollection<DataConnection> DataConnections { get; set; }
    }
}
