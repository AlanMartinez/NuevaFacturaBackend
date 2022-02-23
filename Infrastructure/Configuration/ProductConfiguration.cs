using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(x => x.Id);

            builder.HasData(
                new { Id = 1, Name = "Product1", Price = 100.0m, Code = "11111" },
                new { Id = 2, Name = "Product2", Price = 200.0m, Code = "22222" },
                new { Id = 3, Name = "Product3", Price = 300.0m, Code = "33333" },
                new { Id = 4, Name = "Product4", Price = 400.0m, Code = "44444" },
                new { Id = 5, Name = "Product5", Price = 500.0m, Code = "55555" },
                new { Id = 6, Name = "Product6", Price = 600.0m, Code = "66666" },
                new { Id = 7, Name = "Product7", Price = 700.0m, Code = "77777" },
                new { Id = 8, Name = "Product8", Price = 800.0m, Code = "88888" }
            );
        }
    }
}