using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> e)
    {
        e.HasKey(x => x.Id);
        e.Property(x => x.Number).IsRequired().HasMaxLength(64);
        e.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);
        e.Property(x => x.TotalAmount).HasColumnType("numeric(18,2)");
        e.HasIndex(x => x.Number).IsUnique();
    }
}
