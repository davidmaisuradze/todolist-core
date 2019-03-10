using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Interfaces.Services;
using TodoList.Domain.Models.User;

namespace TodoList.Api.Controllers
{
    [Route("api/auth")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _userService.GetUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            try
            {
                var result = _userService.Login(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]RegisterRequest model)
        {
            try
            {
                var result = _userService.Register(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
