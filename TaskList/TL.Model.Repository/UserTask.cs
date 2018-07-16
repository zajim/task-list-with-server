using System;
using System.Collections.Generic;

namespace TL.Model.Repository
{
    public partial class UserTask
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }

        public Task Task { get; set; }
        public User User { get; set; }
    }
}
