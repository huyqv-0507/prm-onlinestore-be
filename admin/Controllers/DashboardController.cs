using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using admin.ViewModels;
using Data.Infrastructures;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly OnlineStoreDbContext _dbContext;

        public DashboardController(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("dashboard/orders")]
        public IActionResult Orders()
        {
            return View();
        }

        [Route("dashboard/employees")]
        public IActionResult Employees(string searchName)
        {
            var users = from e in _dbContext.Users
                                select e;
            if (!String.IsNullOrEmpty(searchName))
            {
                users = users.Where(emps => emps.FullName.Contains(searchName));
            }
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModels.Add(new UserViewModel(users.ToList(), user.FullName, user.Username, user.RoleId, getAddressOfStore(user.StoreId), user.Status));
            }
            return View(userViewModels);
        }

        [Route("dashboard/employeedetail")]
        public IActionResult EmployeeDetail(string username)
        {
            User user = _dbContext.Users.Single(user => user.Username == username);

            var names = user.FullName.Split(" ");
            string name = names.Last();
            ViewData["name"] = name;
            return View(user);
        }
        [HttpPost]
        [Route("dashboard/createnewuser")]
        public IActionResult CreateNewUser()
        {
            ViewBag.stores = GetStores();
            ViewBag.roles = GetRoles();

            if (ModelState.IsValid)
            {
                string username = Request.Form["txtUsername"].ToString();
                string password = "1";
                string fullName = Request.Form["txtFullName"].ToString();
                int roleId = getRoleId(Request.Form["role"].ToString());
                int storeId = GetStoreId(Request.Form["store"].ToString());
                bool status = false;
                User user = new User();
                user.Username = username;
                user.Password = password;
                user.FullName = fullName;
                user.RoleId = roleId;
                user.StoreId = storeId;
                user.Status = status;
                _dbContext.Add(user);
                _dbContext.Commit();

                return RedirectToAction("SuccessNotify");
            }
            
            return View();
        }
        

        //custom
        public string getAddressOfStore(int? storeId)
        {
            Store store = null;
            if (storeId == null) return "";
            var storee = _dbContext.Stores.Single(a => a.StoreId == storeId);
                store = storee;
            return store.Address;
        }
        public List<Store> GetStores ()
        {
            return _dbContext.Stores.ToList();
        }
        public int GetStoreId(string address)
        {
            Store store = _dbContext.Stores.Single(store => store.Address.Equals(address));
            return store.StoreId;
        }
        public List<Role> GetRoles ()
        {
            return _dbContext.Roles.ToList();
        }
        public int getRoleId(string roleName)
        {
            Role role = _dbContext.Roles.Single(role => role.RoleName.Equals(roleName));
            return role.RoleId;
        }
        public string SuccessNotify()
        {
            return "Success";
        }
    }
}
