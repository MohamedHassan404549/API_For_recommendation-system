using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BundlesController : ControllerBase
{
    private readonly E_ComerceContext _context;
    private readonly List<string> _allowedExtensions = new List<string> { ".jpg", ".png" };
    private const long _maxAllowedImageSize = 2097152; // 2 MB in bytes

    public BundlesController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/Bundles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bundle>>> GetBundles()
    {
        var bundles = await _context.Bundles.ToListAsync();
        return bundles;
    }

    // GET: api/Bundles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bundle>> GetBundle(int id)
    {
        var bundle = await _context.Bundles.FindAsync(id);

        if (bundle == null)
        {
            return NotFound();
        }

        return bundle;
    }

    // POST: api/Bundles
    [HttpPost]
    public async Task<ActionResult<Bundle>> PostBundle([FromForm] BundleDtos bundleDto)
    {
        if (bundleDto.Bundle_image == null)
            return BadRequest("Poster image is required");

        if (!_allowedExtensions.Contains(Path.GetExtension(bundleDto.Bundle_image.FileName).ToLower()))
            return BadRequest("Only .png and .jpg file formats are allowed");

        if (bundleDto.Bundle_image.Length > _maxAllowedImageSize)
            return BadRequest("Maximum allowed image size is 2MB");

        using var memoryStream = new MemoryStream();
        await bundleDto.Bundle_image.CopyToAsync(memoryStream);

        var bundle = new Bundle
        {
            Bundle_Price = bundleDto.Bundle_Price,
            Bundle_image = memoryStream.ToArray(),
            Bundle_Description = bundleDto.Bundle_Description,
            Admin_Id = bundleDto.Admin_Id
        };

        _context.Bundles.Add(bundle);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBundle), new { id = bundle.Bundle_Id }, bundle);
    }

    // PUT: api/Bundles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBundle([FromForm] int id, BundleDtos bundleDto)
    {
        if (id != bundleDto.Bundle_Id)
        {
            return BadRequest();
        }

        var bundle = await _context.Bundles.FindAsync(id);
        if (bundle == null)
        {
            return NotFound();
        }

        if (bundleDto.Bundle_image != null)
        {
            if (!_allowedExtensions.Contains(Path.GetExtension(bundleDto.Bundle_image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg file formats are allowed");

            if (bundleDto.Bundle_image.Length > _maxAllowedImageSize)
                return BadRequest("Maximum allowed image size is 2MB");

            using var memoryStream = new MemoryStream();
            await bundleDto.Bundle_image.CopyToAsync(memoryStream);
            bundle.Bundle_image = memoryStream.ToArray();
        }

        bundle.Bundle_Price = bundleDto.Bundle_Price;
        bundle.Bundle_Description = bundleDto.Bundle_Description;
        bundle.Admin_Id = bundleDto.Admin_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BundleExists(id))
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

    // DELETE: api/Bundles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBundle(int id)
    {
        var bundle = await _context.Bundles.FindAsync(id);
        if (bundle == null)
        {
            return NotFound();
        }

        _context.Bundles.Remove(bundle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BundleExists(int id)
    {
        return _context.Bundles.Any(e => e.Bundle_Id == id);
    }
}
