using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Infrastructures;
using Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly OnlineStoreDbContext _dbContext;
        public LoginController(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        [Route("login/checkLogin")]
        public async Task<IActionResult> checkLogin()
        {
            string username = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();

            User user = await _dbContext.Users.FirstOrDefaultAsync(user => (user.Username == username) && (user.Password == password));
            await _dbContext.SaveChangesAsync();
            if (user == null)
            {
                ModelState.AddModelError("ERROR", "Invalid account!");
                return View("LoginPage");
            }
             
            return RedirectToAction("employees", "dashboard");
        }
    }
}
