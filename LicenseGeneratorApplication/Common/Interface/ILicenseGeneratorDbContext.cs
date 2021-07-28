using System;
using System.Threading.Tasks;
using LicenseGenerator.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseGenerator.Application.Common.Interface
{
   public interface ILicenseGeneratorDbContext: IDisposable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductDetails> ProductDetails { get; set; }
        DbSet<LicenseLog> LicenseLogs { get; set; }
        Task SaveAsync();

    }
}
