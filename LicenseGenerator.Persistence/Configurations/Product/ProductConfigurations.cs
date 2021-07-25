using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LicenseGenerator.Persistence.Configurations.Product
{
    public class ProductConfigurations : IEntityTypeConfiguration<LicenseGenerator.Model.Models.Product>
    {
        public void Configure(EntityTypeBuilder<LicenseGenerator.Model.Models.Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(e => e.ProductDetails)
               .WithOne(e => e.Product)
               .HasForeignKey(e => e.ProductId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
