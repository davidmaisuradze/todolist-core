using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Models.User;

namespace TodoList.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUsers();
        AuthenticationResponse Login(LoginRequest model);
        bool Register(RegisterRequest model);
    }
}
