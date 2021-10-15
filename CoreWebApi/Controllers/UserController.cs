using CoreWebApi.Models;
using CoreWebApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "UserDoc")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] authenticateViewModel authenticateViewModel)
        {
            var user = _userRepository.Authenticate(authenticateViewModel.UserName, authenticateViewModel.Password);
            if (user == null)
                return BadRequest("Wrong username and password");
            return Ok(user);
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var isUniqueUser = _userRepository.IsUniqueUser(user.UserName);
                if (!isUniqueUser)
                    return BadRequest("Username must be unique");
                var userInfo = _userRepository.Register(user.UserName, user.Password);
                if (userInfo == null)
                    return BadRequest();
            }
            return Ok();
        }

    }
}
