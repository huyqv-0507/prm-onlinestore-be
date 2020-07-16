using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class ShoeRepository : RepositoryBase<Shoe>, IShoeRepository
    {
        public ShoeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
