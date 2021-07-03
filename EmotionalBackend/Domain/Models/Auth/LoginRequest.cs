using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Models.Auth
{
    public class LoginRequest
    {
        public string Email { set; get; }
        public string Password { set; get; }
    }
}
