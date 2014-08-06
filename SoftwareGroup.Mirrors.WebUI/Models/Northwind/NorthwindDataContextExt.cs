using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Models.Northwind
{
    public class NorthwindDataContextExt: NorthwindDataContext
    {
        static string ConnectionString
        {
            get
            {
                string sqlExpressString = ConfigurationManager.ConnectionStrings["NWindConnectionString"].ConnectionString;
                return sqlExpressString;
            }
        }
        public NorthwindDataContextExt() : base(ConnectionString) { }
    }
}