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
public class ProductReviewsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public ProductReviewsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/ProductReviews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_ReviewDtos>>> GetProductReviews()
    {
        var productReviews = await _context.Product_Reviews.ToListAsync();

        var dtos = productReviews.Select(pr => new Product_ReviewDtos
        {
            comment = pr.comment,
            rating = pr.rating,
            Cus_Id = pr.Cus_Id,
            P_Id = pr.P_Id
        }).ToList();

        return dtos;
    }

    // GET: api/ProductReviews/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product_ReviewDtos>> GetProductReview(int id)
    {
        var productReview = await _context.Product_Reviews.FindAsync(id);

        if (productReview == null)
        {
            return NotFound();
        }

        var dto = new Product_ReviewDtos
        {
            comment = productReview.comment,
            rating = productReview.rating,
            Cus_Id = productReview.Cus_Id,
            P_Id = productReview.P_Id
        };

        return dto;
    }

    // POST: api/ProductReviews
    [HttpPost]
    public async Task<ActionResult<Product_ReviewDtos>> PostProductReview(Product_ReviewDtos productReviewDto)
    {
        var productReview = new Product_Review
        {
            comment = productReviewDto.comment,
            rating = productReviewDto.rating,
            Cus_Id = productReviewDto.Cus_Id,
            P_Id = productReviewDto.P_Id
        };

        _context.Product_Reviews.Add(productReview);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductReview), new { id = productReview.Review_Id }, productReviewDto);
    }

    // PUT: api/ProductReviews/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductReview(int id, Product_ReviewDtos productReviewDto)
    {
        if (id != productReviewDto.Cus_Id || id != productReviewDto.P_Id)
        {
            return BadRequest();
        }

        var productReview = await _context.Product_Reviews.FindAsync(id);

        if (productReview == null)
        {
            return NotFound();
        }

        productReview.comment = productReviewDto.comment;
        productReview.rating = productReviewDto.rating;
        productReview.Cus_Id = productReviewDto.Cus_Id;
        productReview.P_Id = productReviewDto.P_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductReviewExists(id))
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

    // DELETE: api/ProductReviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductReview(int id)
    {
        var productReview = await _context.Product_Reviews.FindAsync(id);
        if (productReview == null)
        {
            return NotFound();
        }

        _context.Product_Reviews.Remove(productReview);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductReviewExists(int id)
    {
        return _context.Product_Reviews.Any(e => e.Cus_Id == id || e.P_Id == id);
    }
}
