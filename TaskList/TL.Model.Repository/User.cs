using System;
using System.Collections.Generic;

namespace TL.Model.Repository
{
    public partial class User
    {
        public User()
        {
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
            UserTasks = new HashSet<UserTask>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
