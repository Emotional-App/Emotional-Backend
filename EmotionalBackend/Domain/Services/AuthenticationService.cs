using Emotional.Api.Domain.Contracts;
using Emotional.Api.Domain.Models.Auth;
using Emotional.Common.Auth;
using Emotional.Common.Contracts;
using Emotional.Data.EF;
using Emotional.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emotional.Api.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IRepository<User> _userRepository;
        private IPasswordStorage _encryptPassword;
        private IJwtHandler _jwtHandler;

        public AuthenticationService(
                                IRepository<User> userRepository,
                                IPasswordStorage encryptPassword,
                                IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encryptPassword = encryptPassword;
            _jwtHandler = jwtHandler;
        }

        public JsonWebToken Register(RegisterRequest user)
        {
            try
            {
                if (!IsValidEmail(user.Email))
                {
                    throw new ApplicationException("The email format is invalid.");
                }

                if (GetUserByEmail(user.Email) != null)
                {
                    throw new ApplicationException("The email has been registered.");
                }

                var userModel = new User
                {
                    Id = Guid.NewGuid(),
                    Name = user.UserName,
                    Email = user.Email,
                    HashPassword = _encryptPassword.CreateHash(user.Password)
                };
                
                _userRepository.Add(userModel);
                
                var jsonWebToken = _jwtHandler.Create(userModel.Id.ToString());
                jsonWebToken.UserName = userModel.Name;

                return jsonWebToken;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Register error - " + ex.Message);
            }
        }
     
        public JsonWebToken Login(LoginRequest user)
        {
            try
            {
                if (!IsValidEmail(user.Email))
                {
                    throw new ApplicationException("The email format is invalid.");
                }

                var existingUser = GetUserByEmail(user.Email);
                if (existingUser == null)
                {
                    throw new ApplicationException("The email has not been registered.");
                }

                var passwordCorrect = _encryptPassword.VerifyPassword(user.Password, existingUser.HashPassword);
                if (!passwordCorrect)
                {
                    throw new ApplicationException("Invalid credentials");
                }

                var jsonWebToken = _jwtHandler.Create(existingUser.Id.ToString());
                jsonWebToken.UserName = existingUser.Name;

                return jsonWebToken;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login error - " + ex.Message);
            }
        }

        #region Helpers

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public User GetUserByEmail(string email)
        {
            var existingUser = _userRepository.Find(x => x.Email == email);

            return existingUser;
        }

        #endregion
    }
}
