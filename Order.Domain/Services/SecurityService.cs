﻿using Order.Domain.Interfaces.Services;
using Order.Domain.Models;
using Order.Domain.Validations.Base;

namespace Order.Domain.Services
{
    public class SecurityService : ISecurityService
    {
        public Task<Response<bool>> ComparePassword(string password, string confirmPassword)
        {
            var isEquals = password.Trim().Equals(confirmPassword.Trim());
            return Task.FromResult(Response.Ok<bool>(isEquals));
        }

        public Task<Response<string>> EncryptPassword(string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return Task.FromResult(Response.Ok<string>(passwordHash));
        }

        public Task<Response<bool>> VerifyPassword(string password, UserModel user)
        {
            var validPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return Task.FromResult(Response.Ok<bool>(validPassword));
        }
    }
}