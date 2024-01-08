using Asp.Versioning;
using etcsoft.org.catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace etcsoft.org.catalog;

[ApiController]
[ApiVersion(1)]
[Route("api/v1/[controller]")]
public class CatalogController(CatalogService catalogService) : ControllerBase
{
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> Create([FromBody] CatalogReq request)
    {
        var catalog = await catalogService.CreateCatalog(request);
        return CreatedAtAction("create", catalog);
    }

    
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll()
    {
        var catalogs = await catalogService.GetCatalogs();
        return Ok(catalogs);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> Get(Guid id)
    {
        var catalog = await catalogService.GetCatalog(id);
        if (catalog is null) return NotFound("Catalog not found...!");
        return Ok(catalog);
    }
    
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var catalog = await catalogService.DeleteCatalog(id);
        if (catalog is null) return NotFound("Catalog not found...!");
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] CatalogUpdateReq request, Guid id)
    {
        var catalog = await catalogService.UpdateCatalog(id, request);
        return Ok(catalog);
    }
}