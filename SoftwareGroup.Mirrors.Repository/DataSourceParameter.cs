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
    
    public partial class DataSourceParameter
    {
        public int ParameterID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public int SourceID { get; set; }
    
        public virtual DataSource DataSource { get; set; }
    }
}
