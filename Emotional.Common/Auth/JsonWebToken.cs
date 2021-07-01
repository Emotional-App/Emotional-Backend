using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Common.Auth
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public long Expires { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}