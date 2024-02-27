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
public class ProductWishListsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public ProductWishListsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/ProductWishLists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_Wish_ListDtos>>> GetProductWishLists()
    {
        var productWishLists = await _context.Product_Wish_Lists.ToListAsync();

        var dtos = productWishLists.Select(pwl => new Product_Wish_ListDtos
        {
            W_Id = pwl.W_Id,
            P_Id = pwl.P_Id
        }).ToList();

        return dtos;
    }

    // GET: api/ProductWishLists/5
    [HttpGet("{w_id}/{p_id}")]
    public async Task<ActionResult<Product_Wish_ListDtos>> GetProductWishList(int w_id, int p_id)
    {
        var productWishList = await _context.Product_Wish_Lists.FindAsync(w_id, p_id);

        if (productWishList == null)
        {
            return NotFound();
        }

        var dto = new Product_Wish_ListDtos
        {
            W_Id = productWishList.W_Id,
            P_Id = productWishList.P_Id
        };

        return dto;
    }

    // POST: api/ProductWishLists
    [HttpPost]
    public async Task<ActionResult<Product_Wish_ListDtos>> PostProductWishList(Product_Wish_ListDtos productWishListDto)
    {
        var productWishList = new Product_Wish_List
        {
            W_Id = productWishListDto.W_Id,
            P_Id = productWishListDto.P_Id
        };

        _context.Product_Wish_Lists.Add(productWishList);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductWishList), new { w_id = productWishList.W_Id, p_id = productWishList.P_Id }, productWishListDto);
    }

    // PUT: api/ProductWishLists/5/10
    [HttpPut("{w_id}/{p_id}")]
    public async Task<IActionResult> PutProductWishList(int w_id, int p_id, Product_Wish_ListDtos productWishListDto)
    {
        if (w_id != productWishListDto.W_Id || p_id != productWishListDto.P_Id)
        {
            return BadRequest();
        }

        var productWishList = await _context.Product_Wish_Lists.FindAsync(w_id, p_id);
        if (productWishList == null)
        {
            return NotFound();
        }

        productWishList.W_Id = productWishListDto.W_Id;
        productWishList.P_Id = productWishListDto.P_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductWishListExists(w_id, p_id))
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

    // DELETE: api/ProductWishLists/5
    [HttpDelete("{w_id}/{p_id}")]
    public async Task<IActionResult> DeleteProductWishList(int w_id, int p_id)
    {
        var productWishList = await _context.Product_Wish_Lists.FindAsync(w_id, p_id);
        if (productWishList == null)
        {
            return NotFound();
        }

        _context.Product_Wish_Lists.Remove(productWishList);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductWishListExists(int w_id, int p_id)
    {
        return _context.Product_Wish_Lists.Any(e => e.W_Id == w_id && e.P_Id == p_id);
    }
}
