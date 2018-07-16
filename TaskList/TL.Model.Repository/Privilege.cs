using System;
using System.Collections.Generic;

namespace TL.Model.Repository
{
    public class Privilege
    {
        public Privilege()
        {
            RolePrivileges = new HashSet<RolePrivilege>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
