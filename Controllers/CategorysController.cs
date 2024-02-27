using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly E_ComerceContext _context;
    private readonly List<string> _allowedExtensions = new List<string> { ".jpg", ".png" };
    private const long _maxAllowedPosterSize = 2097152; // 2 MB in bytes

    public CategoriesController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/Categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDtos>>> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();

        var dtos = categories.Select(c => new CategoryDtos
        {
            C_Id = c.C_Id,
            C_Name = c.C_Name,
            C_Description = c.C_Description,
            C_Image = null, // Ensure to handle this properly based on your application logic
            Admin_Id = c.Admin_Id
        }).ToList();

        return dtos;
    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDtos>> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        var dto = new CategoryDtos
        {
            C_Id = category.C_Id,
            C_Name = category.C_Name,
            C_Description = category.C_Description,
            C_Image = null, // Ensure to handle this properly based on your application logic
            Admin_Id = category.Admin_Id
        };

        return dto;
    }


    // POST: api/Categories
    [HttpPost]
    public async Task<ActionResult<CategoryDtos>> PostCategory([FromForm]CategoryDtos categoryDto)
    {
        if (categoryDto.C_Image == null)
            return BadRequest("Image is required");

        if (!_allowedExtensions.Contains(Path.GetExtension(categoryDto.C_Image.FileName).ToLower()))
            return BadRequest("Only .png and .jpg file formats are allowed");

        if (categoryDto.C_Image.Length > _maxAllowedPosterSize)
            return BadRequest("Maximum allowed image size is 2MB");

        using var memoryStream = new MemoryStream();
        await categoryDto.C_Image.CopyToAsync(memoryStream);

        var category = new Category
        {
            C_Name = categoryDto.C_Name,
            C_Description = categoryDto.C_Description,
            C_Image = memoryStream.ToArray(),
            Admin_Id = categoryDto.Admin_Id
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategory), new { id = category.C_Id }, categoryDto);
    }

    // PUT: api/Categories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory([FromForm] int id, CategoryDtos categoryDto)
    {
        if (id != categoryDto.C_Id)
        {
            return BadRequest("Category ID mismatch");
        }

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        if (categoryDto.C_Image != null)
        {
            if (!_allowedExtensions.Contains(Path.GetExtension(categoryDto.C_Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg file formats are allowed");

            if (categoryDto.C_Image.Length > _maxAllowedPosterSize)
                return BadRequest("Maximum allowed image size is 2MB");

            using var memoryStream = new MemoryStream();
            await categoryDto.C_Image.CopyToAsync(memoryStream);
            category.C_Image = memoryStream.ToArray();
        }

        category.C_Name = categoryDto.C_Name;
        category.C_Description = categoryDto.C_Description;
        category.Admin_Id = categoryDto.Admin_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
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

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.C_Id == id);
    }
}
