using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain;

namespace Restaurant.Infrastructure.Persistence.Configurations;

internal sealed class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> b)
    {
        b.ToTable("Points");

        b.Property(x => x.CreatedAt).HasColumnType("timestamptz");
    }
}
