using System;
using System.Collections.Generic;

namespace TL.Model.Business
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
