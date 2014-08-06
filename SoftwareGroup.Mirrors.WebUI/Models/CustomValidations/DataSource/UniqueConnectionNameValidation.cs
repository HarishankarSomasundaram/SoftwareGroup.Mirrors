using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using SoftwareGroup.Mirrors.Infra;
using SoftwareGroup.Mirrors.Core.Service;
using SoftwareGroup.Mirrors.DataEntity.DataSource;

namespace SoftwareGroup.Mirrors.WebUI.Models.CustomValidations.DataSource
{
    public class UniqueConnectionNameValidationAttribute : ValidationAttribute
    {
        public UniqueConnectionNameValidationAttribute()
        {
            ErrorMessage = "The Connection Name already exists";
        }
        public override bool IsValid(object value)
        {
            ConnectionDetailViewModel connection = value as ConnectionDetailViewModel;
            if (connection == null)
            //    || string.IsNullOrEmpty(app.ClientName) ||
            //app.Date == null)
            {
                
                return true;
            }
            else
            {
                if (connection.NewOrExistingConnection == "New Connection")
                {
                    var service = IoC.Resolve<IDataSourceService>();
                    var existingConnection = service.GetConnection(connection.ConnectionName);
                    if (existingConnection == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }

            }
        }
    }
}