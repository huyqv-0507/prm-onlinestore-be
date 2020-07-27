using System;
using Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlinestore.Controllers
{
    [Route("api/v1/roles")]
    public class RolesController : Controller
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }

        //GET api/v1/roles
        [HttpGet]
        public IActionResult getRoles()
        {
            var roles = _service.getRoles();
            if (roles == null) return BadRequest();
            return Ok(roles);
        }

        //POST api/v1/roles
        [HttpPost]
        public IActionResult addRole(RoleModel roleModel)
        {
            var role = roleModel.Adapt<Role>();
            try
            {
                _service.AddRole(role);

                _service.Save();
            }
            catch (Exception ex)
            {
                return BadRequest("Add role failed - " + ex.Message);
            }
            return Ok(role);
        }
        [HttpPut]
        public IActionResult updateRole()
        {
            return Ok();
        }
    }
}
