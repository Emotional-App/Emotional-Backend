using System;
using System.Collections.Generic;
using System.Text;

namespace Emotional.Common.Security
{
    public interface IUserState
    {
        Guid UId { get; set; }
        string Language { get; set; }
        string Culture { get; set; }
        string TimezoneIdentifier { get; set; }
        string Role { get; set; }
    }

    public class UserState : IUserState
    {
        public Guid UId { get; set; }
        public string Language { get; set; }
        public string Culture { get; set; }
        public string TimezoneIdentifier { get; set; }
        public string Role { get; set; }
    }
}
