using System;
using System.Collections.Generic;

namespace TL.Model.Repository
{
    public partial class Task
    {
        public Task()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
