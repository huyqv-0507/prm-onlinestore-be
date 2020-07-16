using System;
using System.Linq;
using Data.Models;

namespace Services.IServices
{
    public interface IRoleService
    {
        IQueryable<Role> getRoles();
        void AddRole(Role role);
        void Save();
    }
}
