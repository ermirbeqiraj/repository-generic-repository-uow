using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EF.SqlServer.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Created).HasDefaultValueSql("GetDate()").IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
