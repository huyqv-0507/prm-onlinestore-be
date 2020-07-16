using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
