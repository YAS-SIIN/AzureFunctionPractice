 

namespace AzureFunctionPractice.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; } 
    public string Description { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}