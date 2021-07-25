using LicenseGenerator.Application.Common.Interface;
using LicenseGenerator.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LicenseGenerator.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LicenseGeneratorDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LicenseDatabase"));
                options.EnableSensitiveDataLogging();
            });
       services.AddScoped<ILicenseGeneratorDbContext>(provider => provider.GetService<LicenseGeneratorDbContext>());

            return services;
        }
    }
}
