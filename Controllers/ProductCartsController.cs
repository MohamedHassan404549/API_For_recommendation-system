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
public class ProductCartsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public ProductCartsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/ProductCarts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_CartDtos>>> GetProductCarts()
    {
        var productCarts = await _context.Product_Carts.ToListAsync();

        var dtos = productCarts.Select(pc => new Product_CartDtos
        {
            P_Id = pc.P_Id,
            Cart_Id = pc.Cart_Id
        }).ToList();

        return dtos;
    }

    // GET: api/ProductCarts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product_CartDtos>> GetProductCart(int id)
    {
        var productCart = await _context.Product_Carts.FindAsync(id);

        if (productCart == null)
        {
            return NotFound();
        }

        var dto = new Product_CartDtos
        {
            P_Id = productCart.P_Id,
            Cart_Id = productCart.Cart_Id
        };

        return dto;
    }

    // POST: api/ProductCarts
    [HttpPost]
    public async Task<ActionResult<Product_CartDtos>> PostProductCart(Product_CartDtos productCartDto)
    {
        var productCart = new Product_Cart
        {
            P_Id = productCartDto.P_Id,
            Cart_Id = productCartDto.Cart_Id
        };

        _context.Product_Carts.Add(productCart);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductCart), new { id = productCart.P_Id }, productCartDto);
    }

    // PUT: api/ProductCarts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductCart(int id, Product_CartDtos productCartDto)
    {
        if (id != productCartDto.P_Id || id != productCartDto.Cart_Id)
        {
            return BadRequest();
        }

        var productCart = await _context.Product_Carts.FindAsync(id);

        if (productCart == null)
        {
            return NotFound();
        }

        productCart.P_Id = productCartDto.P_Id;
        productCart.Cart_Id = productCartDto.Cart_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductCartExists(id))
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

    // DELETE: api/ProductCarts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductCart(int id)
    {
        var productCart = await _context.Product_Carts.FindAsync(id);
        if (productCart == null)
        {
            return NotFound();
        }

        _context.Product_Carts.Remove(productCart);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductCartExists(int id)
    {
        return _context.Product_Carts.Any(e => e.P_Id == id);
    }
}
