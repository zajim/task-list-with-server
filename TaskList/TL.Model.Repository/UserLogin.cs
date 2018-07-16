using System;
using System.Collections.Generic;
using System.Text;

namespace TL.Model.Repository
{
    public class UserLogin
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ClientId { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpire { get; set; }

        public User User { get; set; }
    }
}
