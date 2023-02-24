using e_Hospital.Application;
using e_Hospital.Application.Abstractions;
using e_Hospital.Infrastructure.Persistence;
using e_Hospital.Infrastructure.Services;
using InstalmentSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace e_Hospital.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IHashService, HashService>();
            services.AddScoped<ITokenService, JWTService>();

            return services;
        }
    }
}
