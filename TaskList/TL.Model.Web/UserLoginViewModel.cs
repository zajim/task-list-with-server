using System;
using System.Collections.Generic;
using System.Text;

namespace TL.Model.Web
{
    public class UserLoginViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ClientId { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpire { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<string> Privileges { get; set; }

        public UserViewModel User { get; set; }
    }
}
