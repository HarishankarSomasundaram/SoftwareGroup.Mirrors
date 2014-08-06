using SoftwareGroup.Mirrors.Core.Service;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace SoftwareGroup.Mirrors.WebUI.Models
{    
    public class UserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }        
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public int UserId { get; set; }

        public bool VerifyUser()
        {
            var service = IoC.Resolve<IUserService>();
            var user = service.Get(UserName);
            if (user != null && user.PasswordHash == CreatePasswordHash(Password))
            {
                this.UserId = user.UserId;
                return true;
            }
            return false;
        }

        private string CreatePasswordHash(string Password)
        {
            return Password;
        }
    }

}
