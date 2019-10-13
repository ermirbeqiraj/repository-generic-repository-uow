using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EF.SqlServer.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.VIN).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Model).HasMaxLength(100);

            builder.Property(x => x.LastService).IsRequired();

            builder.Property(x => x.Created).HasDefaultValueSql("GetDate()").IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
