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
    
    public partial class DataSourceType
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
