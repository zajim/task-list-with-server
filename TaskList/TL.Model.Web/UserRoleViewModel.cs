using System;

namespace TL.Model.Web
{
    public class UserRoleViewModel
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public UserViewModel User { get; set; }

        public RoleViewModel Role { get; set; }
    }
}
