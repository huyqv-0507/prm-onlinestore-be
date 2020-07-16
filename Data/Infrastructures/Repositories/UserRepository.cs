using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
