using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace API.Services
{    
    public static class AuthService
    {
        public static IServiceCollection GetAuthServices(this IServiceCollection services, IConfiguration  configuration)
        {
            var secretKey = configuration.GetSection("SecretKey").Value;
            var simmetricKey = ASCIIEncoding.ASCII.GetBytes(secretKey);

            TokenValidationParameters validationParameters = new TokenValidationParameters 
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(simmetricKey),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            services.AddScoped<IAuthRepository, AuthRepository>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => opt.TokenValidationParameters = validationParameters);
            
            return services;
        }
    }
}