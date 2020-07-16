using System;
namespace Data.Infrastructures
{
    public interface IDbFactory
    {
        OnlineStoreDbContext Init();
    }
    public class DbFactory : Disposable, IDbFactory
    {
        OnlineStoreDbContext dbContext;
        public OnlineStoreDbContext Init()
        {
            return dbContext ?? (dbContext = new OnlineStoreDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
