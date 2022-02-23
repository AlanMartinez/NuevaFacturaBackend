using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Facturas");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.InvoiceNumber).IsRequired();

            builder.HasOne(x => x.Customer)
               .WithMany(u => u.Invoices)
               .HasForeignKey(x => x.CustomerId);
        }
    }
}
