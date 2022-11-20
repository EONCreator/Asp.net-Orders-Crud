using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsuManagement.OrdersCrud.Domain.Services.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Number).IsRequired();

            builder
                .HasOne(o => o.Provider)
                .WithMany()
                .HasForeignKey(o => o.ProviderId)
                .IsRequired();

            builder.HasIndex(o => new { o.Number, o.ProviderId }).IsUnique();

            builder.Property(c => c.Date).IsRequired();
        }
    }
}
