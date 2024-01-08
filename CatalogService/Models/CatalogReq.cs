namespace etcsoft.org.catalog.Models;

public class CatalogReq
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public string? PictureFileName { get; set; }
    public string? PictureUri { get; set; }
    // public required Guid BrandId { get; set; }
    
    public Catalog? CreateCatalog()
    {
        var utcNow = DateTime.UtcNow;
        return new Catalog
        {
            Id = Guid.NewGuid(),
            CreateAt = utcNow,
            ModifiedAt = utcNow,
            Name = Name,
            Description = Description,
            Price = Price,
            PictureUri = PictureUri,
            PictureFileName = PictureFileName
        };
    }
}