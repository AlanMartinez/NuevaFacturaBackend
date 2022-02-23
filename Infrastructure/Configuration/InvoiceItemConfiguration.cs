using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("DetalleFactura");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Invoice)
               .WithMany(u => u.Items)
               .HasForeignKey(x => x.InvoiceId);

            builder.HasOne(x => x.Product)
               .WithMany(u => u.Items)
               .HasForeignKey(x => x.ProductId);
        }
    }
}
