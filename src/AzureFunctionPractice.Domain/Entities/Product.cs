using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;  

namespace AzureFunctionPractice.Domain.Entities;

public class Product : IEntityTypeConfiguration<Product>
{
    public string Name { get; set; }
    public decimal Price { get; set; }



    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Price).IsRequired();
    }
     
}
 