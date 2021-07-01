using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Models.Auth
{
    public class RegisterRequest
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public bool isAgreeTerms { set; get; }
    }
}
