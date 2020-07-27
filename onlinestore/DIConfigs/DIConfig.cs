using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.Services;

namespace onlinestore.DIConfigs
{
    public class DIConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IShoeRepository, ShoeRepository>();

            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IShoeService, ShoeService>();
        }
    }
}
