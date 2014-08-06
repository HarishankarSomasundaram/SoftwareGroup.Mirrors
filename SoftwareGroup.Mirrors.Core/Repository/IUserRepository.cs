using SoftwareGroup.Mirrors.DataEntity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Core.Repository
{
    public interface IUserRepository
    {
        int Create(UserDetail detail);
        
        UserDetail Get(int userId);

        UserDetail Get(string username);

        List<UserDetail> GetAll();

        void Update(UserDetail detail);

        void Delete(int userId);

        List<UserRole> GetRoles(int userId);
    }
}

