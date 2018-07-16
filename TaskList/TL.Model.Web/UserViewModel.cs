using System;
using System.Collections.Generic;

namespace TL.Model.Web
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public ICollection<UserLoginViewModel> UserLogins { get; set; }
        public ICollection<UserRoleViewModel> UserRoles { get; set; }
        public ICollection<UserTaskViewModel> UserTasks { get; set; }
    }
}
