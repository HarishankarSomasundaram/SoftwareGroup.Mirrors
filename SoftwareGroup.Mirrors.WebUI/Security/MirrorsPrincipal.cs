using SoftwareGroup.Mirrors.Core.Service;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftwareGroup.Mirrors.DataEntity.User;

namespace SoftwareGroup.Mirrors.WebUI.Security
{
    public class MirrorsPrincipal : System.Security.Principal.IPrincipal
    {
        public System.Security.Principal.IIdentity Identity
        {
            get;
            private set;
        }

        public MirrorsPrincipal(string userName, string authType)
        {
            this.Identity = new MirrorsIdentity(userName, authType);
        }

        public bool IsInRole(string role)
        {
            var userService = IoC.Resolve<IUserService>();
            var userRoles = userService.GetRoles(((MirrorsIdentity)this.Identity).UserId);
            return userRoles.Count(ur => ur == (UserRole)Enum.Parse(typeof(UserRole), role)) > 0;
        }
    }

    public class MirrorsIdentity : System.Security.Principal.IIdentity
    {
        public MirrorsIdentity(string userName, string type)
        {
            var userService = IoC.Resolve<IUserService>();
            var userDetail = userService.Get(userName);
            if (userDetail != null)
            {
                this.UserId = userDetail.UserId;
                this.UserName = userDetail.Username;
                this.Name = userDetail.FirstName + " " + userDetail.LastName;
                this.AuthenticationType = type;
                this.IsAuthenticated = true;
            }
        }

        public int UserId { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
    }

}