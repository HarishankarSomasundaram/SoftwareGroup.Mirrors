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
    public class CredentialsMustMatchValidationAttribute:ValidationAttribute
    {
        public CredentialsMustMatchValidationAttribute()
        {
            ErrorMessage = "Authentication Mode, User Id and Password must match with those of the existing connection";
        }
            

          public override bool IsValid(object value)
        {
            ConnectionDetailViewModel connection = value as ConnectionDetailViewModel;
            if (connection == null )
            //    || string.IsNullOrEmpty(app.ClientName) ||
            //app.Date == null)
            {
                // we don't have a model of the right type to validate, or we don't have
                // the values for the ClientName and Date properties we require
                return true;
            }
            else
            {
                if(connection.NewOrExistingConnection == "New Connection" || connection.ConnectionTypeID==2)
                {
                    return true;
                }
                else
                {
                    var service = IoC.Resolve<IDataSourceService>();
                    var existingConnection = service.GetConnection(connection.ConnectionName);
                    if(connection.AuthenticationType == existingConnection.AuthenticationType)
                    {
                        if (connection.AuthenticationType == "W") return true;
                        else
                        {
                            if((connection.UserName == existingConnection.UserID)
                                && (connection.Password == existingConnection.Password))
                                    return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }
    }
  
}