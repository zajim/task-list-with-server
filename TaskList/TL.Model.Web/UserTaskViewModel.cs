using System;

namespace TL.Model.Web
{
    public class UserTaskViewModel
    {
        public Guid UserId { get; set; }

        public Guid TaskId { get; set; }

        public UserViewModel User { get; set; }

        public TaskViewModel Task { get; set; }
    }
}
