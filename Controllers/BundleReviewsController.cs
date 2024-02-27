using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class BundleReviewsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public BundleReviewsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/BundleReviews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bundle_ReviewDtos>>> GetBundleReviews()
    {
        var bundleReviews = await _context.Bundle_Reviews.ToListAsync();

        var dtos = bundleReviews.Select(br => new Bundle_ReviewDtos
        {
            B_Review_Comment = br.B_Review_Comment,
            Reting = br.Reting,
            Cus_Id = br.Cus_Id,
            Bundle_Id = br.Bundle_Id
        }).ToList();

        return dtos;
    }

    // GET: api/BundleReviews/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bundle_ReviewDtos>> GetBundleReview(int id)
    {
        var bundleReview = await _context.Bundle_Reviews.FindAsync(id);

        if (bundleReview == null)
        {
            return NotFound();
        }

        var dto = new Bundle_ReviewDtos
        {
            B_Review_Comment = bundleReview.B_Review_Comment,
            Reting = bundleReview.Reting,
            Cus_Id = bundleReview.Cus_Id,
            Bundle_Id = bundleReview.Bundle_Id
        };

        return dto;
    }

    // POST: api/BundleReviews
    [HttpPost]
    public async Task<ActionResult<Bundle_ReviewDtos>> PostBundleReview(Bundle_ReviewDtos bundleReviewDto)
    {
        var bundleReview = new Bundle_Review
        {
            B_Review_Comment = bundleReviewDto.B_Review_Comment,
            Reting = bundleReviewDto.Reting,
            Cus_Id = bundleReviewDto.Cus_Id,
            Bundle_Id = bundleReviewDto.Bundle_Id
        };

        _context.Bundle_Reviews.Add(bundleReview);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBundleReview), new { id = bundleReview.B_Review_Id }, bundleReviewDto);
    }

    // PUT: api/BundleReviews/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBundleReview(int id, Bundle_ReviewDtos bundleReviewDto)
    {
        if (id != bundleReviewDto.Bundle_Id)
        {
            return BadRequest();
        }

        var bundleReview = await _context.Bundle_Reviews.FindAsync(id);

        if (bundleReview == null)
        {
            return NotFound();
        }

        bundleReview.B_Review_Comment = bundleReviewDto.B_Review_Comment;
        bundleReview.Reting = bundleReviewDto.Reting;
        bundleReview.Cus_Id = bundleReviewDto.Cus_Id;
        bundleReview.Bundle_Id = bundleReviewDto.Bundle_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BundleReviewExists(id))
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

    // DELETE: api/BundleReviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBundleReview(int id)
    {
        var bundleReview = await _context.Bundle_Reviews.FindAsync(id);
        if (bundleReview == null)
        {
            return NotFound();
        }

        _context.Bundle_Reviews.Remove(bundleReview);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BundleReviewExists(int id)
    {
        return _context.Bundle_Reviews.Any(e => e.B_Review_Id == id);
    }
}
