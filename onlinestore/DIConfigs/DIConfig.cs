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

            services.AddTransient<IRoleService, RoleService>();
        }
    }
}
