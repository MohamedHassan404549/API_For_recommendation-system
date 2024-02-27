using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Humanizer;

[Authorize]

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController : ControllerBase
{
    private readonly E_ComerceContext _context;
    private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
    private long _maxAllowedPosterSize = 2097152;

    public SubCategoriesController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/SubCategories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubCategoryDtos>>> GetSubCategories()
    {
        var subCategories = await _context.SubCatagories.ToListAsync();

        var dtos = subCategories.Select(sc => new SubCategoryDtos
        {
            Sub_C_Id = sc.Sub_C_Id,
            // Assuming you don't need to return the actual image data in the DTO, just the filename or some identifier
            // Sub_C_image = sc.Sub_C_image, 
            sub_c_Description = sc.sub_c_Description,
            Admin_Id = sc.Admin_Id,
            C_Id = sc.C_Id
        }).ToList();

        return dtos;
    }

    // GET: api/SubCategories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SubCategoryDtos>> GetSubCategory(int id)
    {
        var subCategory = await _context.SubCatagories.FindAsync(id);

        if (subCategory == null)
        {
            return NotFound();
        }

        var dto = new SubCategoryDtos
        {
            Sub_C_Id = subCategory.Sub_C_Id,
            // Similar to above, assuming you don't need to return the actual image data
            // Sub_C_image = subCategory.Sub_C_image,
            sub_c_Description = subCategory.sub_c_Description,
            Admin_Id = subCategory.Admin_Id,
            C_Id = subCategory.C_Id
        };

        return dto;
    }
    // POST: api/SubCategories
    [HttpPost]
    public async Task<ActionResult<SubCategoryDtos>> PostSubCategory([FromForm] SubCategoryDtos subCategoryDto)
    {
        if (subCategoryDto.Sub_C_image == null)
            return BadRequest("poster is required");

        if (!_allowedExtenstions.Contains(Path.GetExtension(subCategoryDto.Sub_C_image.FileName).ToLower()))
            return BadRequest("only .png and .jpg!");

        if (subCategoryDto.Sub_C_image.Length > _maxAllowedPosterSize)
            return BadRequest("MAx Allowed Size is 2MB!");

      

        using var dateStream = new MemoryStream();
        await subCategoryDto.Sub_C_image.CopyToAsync(dateStream);
        var subCategory = new SubCatagory
        {
            Sub_C_Id = subCategoryDto.Sub_C_Id,
            Sub_C_image =dateStream.ToArray(),
            sub_c_Description = subCategoryDto.sub_c_Description,
            Admin_Id = subCategoryDto.Admin_Id,
            C_Id = subCategoryDto.C_Id
        };

        _context.SubCatagories.Add(subCategory);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSubCategory), new { id = subCategory.Sub_C_Id }, subCategoryDto);
    }

    // PUT: api/SubCategories/5
    // PUT: api/SubCategories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSubCategory([FromForm]int id, SubCategoryDtos subCategoryDto)
    {
        if (id != subCategoryDto.Sub_C_Id)
        {
            return BadRequest();
        }

        var subCategory = await _context.SubCatagories.FindAsync(id);
        if (subCategory == null)
        {
            return NotFound();
        }

        if (subCategoryDto.Sub_C_image != null)
        {
            if (!_allowedExtenstions.Contains(Path.GetExtension(subCategoryDto.Sub_C_image.FileName).ToLower()))
                return BadRequest("only .png and .jpg!");

            if (subCategoryDto.Sub_C_image.Length > _maxAllowedPosterSize)
                return BadRequest("MAx Allowed Size is 2MB!");

            using var dateStream = new MemoryStream();
            await subCategoryDto.Sub_C_image.CopyToAsync(dateStream);
            subCategory.Sub_C_image = dateStream.ToArray();
        }

        subCategory.sub_c_Description = subCategoryDto.sub_c_Description;
        subCategory.Admin_Id = subCategoryDto.Admin_Id;
        subCategory.C_Id = subCategoryDto.C_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SubCategoryExists(id))
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

    // DELETE: api/SubCategories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubCategory(int id)
    {
        var subCategory = await _context.SubCatagories.FindAsync(id);
        if (subCategory == null)
        {
            return NotFound();
        }

        _context.SubCatagories.Remove(subCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SubCategoryExists(int id)
    {
        return _context.SubCatagories.Any(e => e.Sub_C_Id == id);
    }
}
