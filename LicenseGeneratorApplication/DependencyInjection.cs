using System.Reflection;
using LicenseGenerator.Application.Interface.Customer;
using LicenseGenerator.Application.Interface.License;
using LicenseGenerator.Application.Interface.Product;
using LicenseGenerator.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace LicenseGenerator.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ILicenseService, LicenseService>();

            return services;
        }
    }
}
