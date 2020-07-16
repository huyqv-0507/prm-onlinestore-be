using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
