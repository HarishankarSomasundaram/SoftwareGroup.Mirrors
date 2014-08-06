//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftwareGroup.Mirrors.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataSource
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