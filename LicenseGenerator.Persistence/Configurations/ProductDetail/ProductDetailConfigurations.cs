using LicenseGenerator.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LicenseGenerator.Persistence.Configurations.ProductDetail
{
    public class ProductDetailConfigurations : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.EnName).IsRequired();
            builder.HasOne(e => e.Product)
               .WithMany(e => e.ProductDetails)
               .HasForeignKey(e => e.ProductId);

        }
    }
}
