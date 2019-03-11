using System.Collections.Generic;
using TodoList.Domain.Models.Auth;

namespace TodoList.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        IEnumerable<UserModel> GetUsers();
        AuthenticationResponse Login(LoginRequest model);
        bool Register(RegisterRequest model);
    }
}
