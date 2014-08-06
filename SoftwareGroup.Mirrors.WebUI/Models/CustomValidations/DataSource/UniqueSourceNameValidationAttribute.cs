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
    public class UniqueSourceNameValidationAttribute : ValidationAttribute
    {
        public UniqueSourceNameValidationAttribute()
        {
            ErrorMessage = "The Source Name already exists";
        }
        public override bool IsValid(object value)
        {
            if(value==null)
            {
                return true;
            }
            else
            { 
                var service = IoC.Resolve<IDataSourceService>();
                var existingSource = service.GetSource((string)value);
                if (existingSource == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            
        }
    }
}