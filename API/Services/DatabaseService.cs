using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Services
{
    public static class DatabaseService
    {
        public static IServiceCollection GetDbServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            // if(env.IsProduction()) 
            // {
            //      services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
            //      return services;
            // }
            // else{
            //     services.AddDbContext<ApiContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DevelopmentConnection")));
            //     return services;
            // }            

            services.AddDbContext<ApiContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DevelopmentConnection")));
            return services;
            
        }
    }
}