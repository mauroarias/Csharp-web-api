namespace etcsoft.org.catalog.Models;

public class CatalogUpdateReq
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? PictureFileName { get; set; }
    public string? PictureUri { get; set; }
    // public required Guid BrandId { get; set; }
    
    public Catalog UpdateCatalog(Catalog original)
    {
        var utcNow = DateTime.UtcNow;
        return new Catalog
        {
            Id = original.Id,
            CreateAt = original.CreateAt,
            ModifiedAt = utcNow,
            Name = Name ?? original.Name,
            Description = Description ?? original.Description,
            Price = Price ?? original.Price,
            PictureUri = PictureUri ?? original.PictureUri,
            PictureFileName = PictureFileName ?? original.PictureFileName
        };
    }
}