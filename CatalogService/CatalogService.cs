using etcsoft.org.catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace etcsoft.org.catalog;

public class CatalogService(CatalogContext catalogContext)
{
    public async Task<Catalog?> CreateCatalog(CatalogReq catalogReq)
    {
        var catalog = catalogReq.CreateCatalog(); 
        catalogContext.Catalogs.Add(catalog);
        await catalogContext.SaveChangesAsync();
        return catalog;
    }
    
    public async Task<Catalog?> GetCatalog(Guid id)
    {
        return await catalogContext.Catalogs.FindAsync(id);
    }
    
    public async Task<List<Catalog?>> GetCatalogs()
    {
        return await catalogContext.Catalogs.ToListAsync();
    }
    
    public async Task<Catalog?> DeleteCatalog(Guid id)
    {
        var catalog = await catalogContext.Catalogs.FindAsync(id);
        if (catalog is null) return await Task.FromResult<Catalog>(null!);
        catalogContext.Catalogs.Remove(catalog);
        await catalogContext.SaveChangesAsync();
        return catalog;
    }
    
    public async Task<Catalog?> UpdateCatalog(Guid id, CatalogUpdateReq updateReq)
    {
        var catalog = await catalogContext.Catalogs.FindAsync(id);
        if (catalog is null) return await Task.FromResult<Catalog>(null!);
        catalogContext.Catalogs.Update(updateReq.UpdateCatalog(catalog));
        await catalogContext.SaveChangesAsync();
        return catalog;
    }
}