using Microsoft.AspNetCore.Mvc;
using System;
using TodoList.Domain.Interfaces.Services;
using TodoList.Domain.Models.Auth;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _authService.GetUsers();
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var result = _authService.Login(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]RegisterRequest model)
        {
            var result = _authService.Register(model);
            return Ok(result);
        }
    }
}
