using System;
using System.Collections.Generic;

namespace TL.Model.Repository
{
    public partial class Role
    {
        public Role()
        {
            RolePrivileges = new HashSet<RolePrivilege>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePrivilege> RolePrivileges { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
