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

public class CartsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public CartsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/Carts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartDtos>>> GetCarts()
    {
        var carts = await _context.Carts.ToListAsync();

        var dtos = carts.Select(c => new CartDtos
        {
            Cart_Id = c.Cart_Id,
            Cart_Quantity = c.Cart_Quantity,
            Cart_Total_Price = c.Cart_Total_Price
        }).ToList();

        return dtos;
    }

    // GET: api/Carts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CartDtos>> GetCart(int id)
    {
        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            return NotFound();
        }

        var dto = new CartDtos
        {
            Cart_Id = cart.Cart_Id,
            Cart_Quantity = cart.Cart_Quantity,
            Cart_Total_Price = cart.Cart_Total_Price
        };

        return dto;
    }

    // POST: api/Carts
    [HttpPost]
    public async Task<ActionResult<CartDtos>> PostCart(CartDtos cartDto)
    {
        var cart = new Cart
        {
            Cart_Quantity = cartDto.Cart_Quantity,
            Cart_Total_Price = cartDto.Cart_Total_Price
        };

        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCart), new { id = cart.Cart_Id }, cartDto);
    }

    // PUT: api/Carts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCart(int id, CartDtos cartDto)
    {
        if (id != cartDto.Cart_Id)
        {
            return BadRequest();
        }

        var cart = await _context.Carts.FindAsync(id);
        if (cart == null)
        {
            return NotFound();
        }

        cart.Cart_Quantity = cartDto.Cart_Quantity;
        cart.Cart_Total_Price = cartDto.Cart_Total_Price;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CartExists(id))
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

    // DELETE: api/Carts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(int id)
    {
        var cart = await _context.Carts.FindAsync(id);
        if (cart == null)
        {
            return NotFound();
        }

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CartExists(int id)
    {
        return _context.Carts.Any(e => e.Cart_Id == id);
    }
}
