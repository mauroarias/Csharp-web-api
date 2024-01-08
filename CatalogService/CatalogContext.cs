using etcsoft.org.catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace etcsoft.org.catalog;

public class CatalogContext(IConfiguration configuration) : DbContext
{
    public DbSet<Catalog> Catalogs { get; set; } = null!;
    public DbSet<CatalogBrand> CatalogBrands { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (configuration.GetConnectionString("DefaultConnection") is not null)
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
        else
            optionsBuilder.UseInMemoryDatabase(databaseName: "catalog");
    }
}