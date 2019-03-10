using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TodoList.Domain.Configuration;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Domain.Interfaces.Services;
using TodoList.Domain.Models.User;

namespace TodoList.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _unitOfWork.Users.Query()
                .Select(x => new UserModel
                {
                    Id = x.Id,
                    Email = x.Email
                }).ToList();

            return users;
        }

        public AuthenticationResponse Login(LoginRequest model)
        {
            var user = _unitOfWork.Users.FindOne(x => x.Email == model.Email);
            if (user == null)
            {
                throw new Exception("user not found");
            }

            // check password
            if (!verifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            // generate jwt token
            var token = generateJwtToken(user.Email);

            var authenticationResponse = new AuthenticationResponse
            {
                Token = token,
                User = new AuthenticatedUser
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };

            return authenticationResponse;
        }

        public bool Register(RegisterRequest model)
        {
            var checkUser = _unitOfWork.Users.FindOne(x => x.Email == model.Email);
            if (checkUser != null)
            {
                throw new Exception("user already exists, try different email");
            }

            byte[] passwordHash, passwordSalt;
            createPasswordHash(model.Password, out passwordHash, out passwordSalt);

            var userEntity = new UserEntity
            {
                Email = model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            _unitOfWork.Users.Add(userEntity);
            _unitOfWork.Save();
            
            return true;
        }


        #region private methods
        private string generateJwtToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor).ToString();

            return token;
        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool verifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        #endregion
    }
}
