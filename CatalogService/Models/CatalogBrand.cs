namespace etcsoft.org.catalog.Models;

public class CatalogBrand
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}