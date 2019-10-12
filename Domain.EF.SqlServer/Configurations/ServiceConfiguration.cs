using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EF.SqlServer.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            
            builder.Property(x => x.Odometer).IsRequired();

            builder.Property(x => x.Created).HasDefaultValueSql("GetDate()").IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
