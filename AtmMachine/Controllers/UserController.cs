using AtmMachine.Interface;
using AtmMachine.Models;
using AtmMachine.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                var newUser = _userService.AddUser(user);
                if (newUser != null)
                    return Ok(newUser);
                else return BadRequest("username already exists");
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpDelete]
        [Route("{userId}")]
        public IActionResult RemoveUser([FromRoute] int userId)
        {
            try
            {
                _userService.RemoveUser(userId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        [Route("update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                var udpatedUser = _userService.UpdateUser(user);
                return Ok(udpatedUser);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LogIn([FromBody] User user)
        {
            try
            {
                var loginedUser = _userService.LogInUser(user);
                if (loginedUser != null)
                    return Ok(loginedUser);
                else return BadRequest("invalid username or password");
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
