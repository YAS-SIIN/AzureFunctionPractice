using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;  

namespace AzureFunctionPractice.Domain.Entities;

public class Product : BaseEntity, IEntityTypeConfiguration<Product>
{
    public string Name { get; set; }
    public decimal Price { get; set; }



    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Price).IsRequired();
    }
     
}
 