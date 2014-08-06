using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SoftwareGroup.Mirrors.DataEntity.DataSource;
using SoftwareGroup.Mirrors.WebUI.Models.CustomValidations.DataSource;

namespace SoftwareGroup.Mirrors.WebUI.Models
{
    public class ConnectionTypeViewModel
    {
        [Required(ErrorMessage = "Please Select a connection Type")]
        public int ConnectionTypeID { get; set; }
        public string ConnectionTypeName { get; set; }
        public string ProviderName { get; set; }

        public List<DataConnectionType> ConnectionTypes { get; set; }
    }

    public class ExcelConnectionViewModel
    { 
        public int ConnectionTypeID { get; set; }
        public string ConnectionTypeName { get; set; }
        public string ProviderName { get; set; }
        public string Url { get; set; }

        public string ConnectionName { get; set; }
    }

    [CredentialsValidationAttribute]
    [UniqueConnectionNameValidationAttribute]
    [CredentialsMustMatchValidationAttribute]
    public class ConnectionDetailViewModel
    {
        

        public List<SelectListItem> NewOrExistingConnections  { get; set; }

        public string NewOrExistingConnection { get; set; }
        public int ConnectionTypeID { get; set; }
        public string ConnectionTypeName { get; set; }
        public string ProviderName { get; set; }

        [Required(ErrorMessage = "Please enter a Server Name")]
        public string ServerName { get; set; }
 
        public string AuthenticationType { get; set; }
        
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<SelectListItem> Databases { get; set; }

        [Required(ErrorMessage = "Please choose a database")]
        public string InitialCatalog { get; set; }

        [Required(ErrorMessage = "Please provide a connection name")]

        public string ConnectionName { get; set; }

    }


   

    public class SourceDetailViewModel
    {
        [Required]
        public int ConnectionTypeID { get; set; }
        public string ConnectionTypeName { get; set; }
        public string ProviderName { get; set; }
        public string NewOrExistingConnection { get; set; }
        public string ServerName { get; set; }
        public string AuthenticationType { get; set; }
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public List<SelectListItem> Objects { get; set; }

        [Required(ErrorMessage = "Please choose an Element")]
        public List<String> Elements { get; set; }

        [Required(ErrorMessage = "Please choose a Measure")]
        public List<String> Measures { get; set; }

        public List<String> ElementsList { get; set; }
        public List<String> MeasuresList { get; set; }
        public string InitialCatalog { get; set; }

        [Required(ErrorMessage = "Please choose an object ")]
        public string Object { get; set; }

        [Required(ErrorMessage = "Please provide a source Name ")]
        [UniqueSourceNameValidationAttribute]
        public string SourceName { get; set; }
        public string ConnectionName { get; set; }


    }

}