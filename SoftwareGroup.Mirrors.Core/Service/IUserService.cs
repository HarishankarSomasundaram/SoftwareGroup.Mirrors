using SoftwareGroup.Mirrors.DataEntity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Core.Service
{
    public interface IUserService
    {
        UserDetail Get(int userId);

        UserDetail Get(string username);

        List<UserDetail> GetAll();

        void Save(UserDetail userDetail);

        void ChangePassword(int userId, string oldPassword, string newPassword);

        List<UserRole> GetRoles(int userId);
    }
}
