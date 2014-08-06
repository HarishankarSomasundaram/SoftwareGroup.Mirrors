using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SoftwareGroup.Mirrors.WebUI.Models.CustomValidations.DataSource
{
    public class CredentialsValidationAttribute : ValidationAttribute
    {
        public CredentialsValidationAttribute()
        {
            ErrorMessage = "User ID and Password is required for SQL server Authentication mode";
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
                return !((connection.UserName == null || connection.UserName == "" || connection.Password == null
                    || connection.Password == "") && connection.AuthenticationType == "S");

            }
        }
    }
}