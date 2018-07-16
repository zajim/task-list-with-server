using System;
using System.Collections.Generic;
using System.Text;

namespace TL.Model.Repository
{
    public class RolePrivilege
    {
        public Guid RoleId { get; set; }
        public Guid PrivilegeId { get; set; }

        public Privilege Privilege { get; set; }
        public Role Role { get; set; }
    }
}
