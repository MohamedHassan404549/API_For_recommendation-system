using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Authorize]

[Route("api/[controller]")]
[ApiController]
public class ProductBundlesController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public ProductBundlesController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/ProductBundles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_BundleDtos>>> GetProductBundles()
    {
        var productBundles = await _context.Product_Bundles.ToListAsync();

        var dtos = productBundles.Select(pb => new Product_BundleDtos
        {
            P_Id = pb.P_Id,
            Bundle_Id = pb.Bundle_Id
        }).ToList();

        return dtos;
    }

    // GET: api/ProductBundles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product_BundleDtos>> GetProductBundle(int id)
    {
        var productBundle = await _context.Product_Bundles.FindAsync(id);

        if (productBundle == null)
        {
            return NotFound();
        }

        var dto = new Product_BundleDtos
        {
            P_Id = productBundle.P_Id,
            Bundle_Id = productBundle.Bundle_Id
        };

        return dto;
    }

    // POST: api/ProductBundles
    [HttpPost]
    public async Task<ActionResult<Product_BundleDtos>> PostProductBundle(Product_BundleDtos productBundleDto)
    {
        var productBundle = new Product_Bundle
        {
            P_Id = productBundleDto.P_Id,
            Bundle_Id = productBundleDto.Bundle_Id
        };

        _context.Product_Bundles.Add(productBundle);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductBundle), new { id = productBundle.P_Id }, productBundleDto);
    }

    // PUT: api/ProductBundles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductBundle(int id, Product_BundleDtos productBundleDto)
    {
        if (id != productBundleDto.P_Id || id != productBundleDto.Bundle_Id)
        {
            return BadRequest();
        }

        var productBundle = await _context.Product_Bundles.FindAsync(id);

        if (productBundle == null)
        {
            return NotFound();
        }

        productBundle.P_Id = productBundleDto.P_Id;
        productBundle.Bundle_Id = productBundleDto.Bundle_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductBundleExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/ProductBundles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductBundle(int id)
    {
        var productBundle = await _context.Product_Bundles.FindAsync(id);
        if (productBundle == null)
        {
            return NotFound();
        }

        _context.Product_Bundles.Remove(productBundle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductBundleExists(int id)
    {
        return _context.Product_Bundles.Any(e => e.P_Id == id);
    }
}
