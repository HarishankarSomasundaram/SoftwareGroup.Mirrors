using SoftwareGroup.Mirrors.Core.Repository;
using SoftwareGroup.Mirrors.DataEntity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Repository
{
    public class UserRepository : IUserRepository
    {
        public int Create(DataEntity.User.UserDetail detail)
        {
            throw new NotImplementedException();
        }

        public DataEntity.User.UserDetail Get(int userId)
        {
            using (var ctx = new MirrorsEntities())
            {
                return (from u in ctx.UserProfiles
                        where u.UserId == userId
                        select new UserDetail()
                        {
                            Username = u.Username,
                            CreatedDate = u.CreatedDate,
                            CreatedUserId = u.CreatedUserId,
                            Email = u.Email,
                            FirstName = u.FirstName,
                            IsActive = u.IsActive ?? false,
                            LastName = u.LastName,
                            LastPasswordFailureDate = u.LastPasswordFailureDate,
                            PasswordChangedDate = u.PasswordChangedDate,
                            PasswordFailuresSinceLastSuccess = u.PasswordFailuresSinceLastSuccess ?? 0,
                            PasswordHash = u.PasswordHash,
                            PasswordSalt = u.PasswordSalt,
                            UpadtedDate = u.UpdatedDate,
                            UpdatedUserId = u.UpdatedUserId,
                            UserId = u.UserId,
                            PersonalPhone = u.PersonalPhone,
                            WorkPhone = u.WorkPhone
                        }).FirstOrDefault();
            }
        }

        public DataEntity.User.UserDetail Get(string username)
        {
            using (var ctx = new MirrorsEntities())
            {
                return (from u in ctx.UserProfiles
                        where u.Username == username
                        select new UserDetail()
                        {
                            Username = u.Username,
                            CreatedDate = u.CreatedDate,
                            CreatedUserId = u.CreatedUserId,
                            Email = u.Email,
                            FirstName = u.FirstName,
                            IsActive = u.IsActive ?? false,
                            LastName = u.LastName,
                            LastPasswordFailureDate = u.LastPasswordFailureDate,
                            PasswordChangedDate = u.PasswordChangedDate,
                            PasswordFailuresSinceLastSuccess = u.PasswordFailuresSinceLastSuccess ?? 0,
                            PasswordHash = u.PasswordHash,
                            PasswordSalt = u.PasswordSalt,
                            UpadtedDate = u.UpdatedDate,
                            UpdatedUserId = u.UpdatedUserId,
                            UserId = u.UserId,
                            PersonalPhone = u.PersonalPhone,
                            WorkPhone = u.WorkPhone
                        }).FirstOrDefault();
            }
        }

        public List<DataEntity.User.UserDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(DataEntity.User.UserDetail detail)
        {
            throw new NotImplementedException();
        }

        public void Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public List<DataEntity.User.UserRole> GetRoles(int userId)
        {
            using (var ctx = new MirrorsEntities())
            {
                var roles = ctx.UserRoleMaps.Where(ur => ur.UserId == userId).ToList();
                var result = new List<DataEntity.User.UserRole>();
                foreach (var item in roles)
                {
                    result.Add((DataEntity.User.UserRole)Enum.Parse(typeof(DataEntity.User.UserRole), item.RoleId.ToString()));
                }
                return result;
            }
        }
    }
}
