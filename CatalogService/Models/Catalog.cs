using System.ComponentModel.DataAnnotations;

namespace etcsoft.org.catalog.Models;

public class Catalog : CatalogReq
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    // public required CatalogBrand Brand { get; set; }
}