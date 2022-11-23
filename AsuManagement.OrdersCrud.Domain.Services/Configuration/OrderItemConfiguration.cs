using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AsuManagement.OrdersCrud.Domain.Services.Configuration
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.Unit).IsRequired();

            builder.Property(o => o.Quantity).HasPrecision(12, 10);
        }
    }
}
