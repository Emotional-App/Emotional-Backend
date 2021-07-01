using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Common.Auth
{
    public interface IPasswordStorage
    {
        string CreateHash(string password);
        bool VerifyPassword(string password, string goodHash);
    }
}
