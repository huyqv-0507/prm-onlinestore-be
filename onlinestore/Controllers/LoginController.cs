using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlinestore.Controllers
{
    [Route("api/v1/login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        //GET api/v1/login/username=?&password=?
        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            var user = _userService.GetUser(username);
            if (user == null) {
                return BadRequest();
            }
            else
            {
                if(user.Password != password)
                {
                    return BadRequest("Password is invalid.");
                }
            }
            return Ok(user);
        }
    }
}
