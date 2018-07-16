using System;
using System.Collections.Generic;
using TL.Model.Enum;

namespace TL.Model.Business
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
