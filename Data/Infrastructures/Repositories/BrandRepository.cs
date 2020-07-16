using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
