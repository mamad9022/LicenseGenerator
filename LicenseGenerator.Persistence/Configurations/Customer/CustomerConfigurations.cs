using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LicenseGenerator.Persistence.Configurations.Customer
{
    public class CustomerConfigurations : IEntityTypeConfiguration<LicenseGenerator.Model.Models.Customer>
    {
        public void Configure(EntityTypeBuilder<LicenseGenerator.Model.Models.Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
