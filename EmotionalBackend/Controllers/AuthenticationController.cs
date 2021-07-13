using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Auth;
using Emotional.Common.Auth;
using Emotional.Common.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Emotional.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="command">CreateUser Model</param>
        /// <response code="201">Successful. Redirects to home page with successful message</response>
        /// <response code="400">BadRequest. User input model is invalid or Email is already registered</response>
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost("signup")]
        [AllowAnonymous]
        public IActionResult Signup([FromBody] RegisterRequest command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        Message = ModelState.Values
                                      .SelectMany(e => e.Errors.Select(m => m.ErrorMessage))
                    });
                }

                command.Email = command.Email.Trim();
                command.UserName = command.UserName.Trim();
                var authenticatedToken = _authenticationService.Register(command);

                return Ok(new { Success = true, Token = authenticatedToken });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = "Please contact the IT Department for futher information" });
            }
        }

        /// <summary>
        /// Allows registered users to sign in 
        /// </summary>
        /// <param name="command">LoginCommand Model</param>
        /// <response code="200">Successful. User's credentials are valid</response>
        /// <response code="400">BadRequest. User input model is invalid</response> 
        /// <response code="401">Unauthorized. User's credentials are invalid</response> 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult LogIn([FromBody] LoginRequest command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(
                        new
                        {
                            Message = ModelState.Values
                        .SelectMany(e => e.Errors.Select(m => m.ErrorMessage))
                        });
                }

                command.Email = command.Email.Trim();
                var authenticateUser = _authenticationService.Login(command);

                return Ok(new { isEmailVerified = true, Token = authenticateUser });
            }
            catch (ApplicationException e)
            {
                return Unauthorized();
            }
        }
    }
}
