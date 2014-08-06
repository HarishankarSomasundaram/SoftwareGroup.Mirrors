using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.Core.Service;
using SoftwareGroup.Mirrors.DataEntity.User;
using SoftwareGroup.Mirrors.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Service
{
    /// <summary>
    /// Implementation for User Service.
    /// </summary>
    public class UserService : IUserService
    {
        public DataEntity.User.UserDetail Get(int userId)
        {
            var repo = IoC.Resolve<IUserRepository>();
            return repo.Get(userId);
        }

        public DataEntity.User.UserDetail Get(string username)
        {
            var repo = IoC.Resolve<IUserRepository>();
            return repo.Get(username);
        }

        public List<DataEntity.User.UserDetail> GetAll()
        {
            var repo = IoC.Resolve<IUserRepository>();
            return repo.GetAll();
        }

        public void Save(DataEntity.User.UserDetail userDetail)
        {
            var repo = IoC.Resolve<IUserRepository>();
            if (userDetail.UserId > 0)
                repo.Update(userDetail);
            else
                repo.Create(userDetail);
        }

        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetRoles(int userId)
        {
            var repo = IoC.Resolve<IUserRepository>();
            return repo.GetRoles(userId);
        }
    }
}
