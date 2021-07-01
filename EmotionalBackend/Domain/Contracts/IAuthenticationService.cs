using Emotional.Api.Domain.Models.Auth;
using Emotional.Common.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Contracts
{
    public interface IAuthenticationService
    {
        JsonWebToken Register(RegisterRequest user);
        JsonWebToken Login(LoginRequest user);
    }
}
