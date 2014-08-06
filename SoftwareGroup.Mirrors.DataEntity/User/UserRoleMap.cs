using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.DataEntity.User
{
    public class UserRoleMap
    {
        public int UserId { get; set; }
        public UserRole Role { get; set; }
        public int CreatedUserId { get; set; }
    }
}
