using System;
using Data.Infrastructures.IRepositories;
using Data.Models;

namespace Data.Infrastructures.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
