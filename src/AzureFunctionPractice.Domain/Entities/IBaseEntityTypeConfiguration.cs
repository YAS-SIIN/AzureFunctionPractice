using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace AzureFunctionPractice.Domain.Entities;

public interface IBaseEntityTypeConfiguration<T>
  where T : BaseEntity
{
    void Configure(EntityTypeBuilder<Product> builder);
}
