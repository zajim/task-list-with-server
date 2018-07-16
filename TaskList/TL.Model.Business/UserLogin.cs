using System;
using System.Collections.Generic;

namespace TL.Model.Business
{
    public class UserLogin
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ClientId { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpire { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<string> Privileges { get; set; }

        public User User { get; set; }
    }
}
