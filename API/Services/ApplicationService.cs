using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Interfaces;
using API.Repositories;
using API.Data;

namespace API.Services
{
    public static class ApplicationService
    {
        public static IServiceCollection GetApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));     

            // That is saying whenever a IBloggerRepository is required, create a BloggerRepository and pass that in.

            return services;
        }
    }
}