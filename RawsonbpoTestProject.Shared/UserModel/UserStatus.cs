using RawsonbpoTestProject.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawsonbpoTestProject.Shared.UserModel
{
    public class UserStatus
    {
        public UserStatusConstants _UserStatus { get; set; } 
        public string? UserStatausMessage { get; set; }
    }
}
