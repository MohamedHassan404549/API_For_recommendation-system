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
public class WishListsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public WishListsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/WishLists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wish_ListDtos>>> GetWishLists()
    {
        var wishLists = await _context.Wish_Lists.ToListAsync();

        var dtos = wishLists.Select(wl => new Wish_ListDtos
        {
            W_Id = wl.W_Id,
            data = wl.data
        }).ToList();

        return dtos;
    }

    // GET: api/WishLists/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Wish_ListDtos>> GetWishList(int id)
    {
        var wishList = await _context.Wish_Lists.FindAsync(id);

        if (wishList == null)
        {
            return NotFound();
        }

        var dto = new Wish_ListDtos
        {
            W_Id = wishList.W_Id,
            data = wishList.data
        };

        return dto;
    }

    // POST: api/WishLists
    [HttpPost]
    public async Task<ActionResult<Wish_ListDtos>> PostWishList(Wish_ListDtos wishListDto)
    {
        var wishList = new Wish_List
        {
            data = wishListDto.data
        };

        _context.Wish_Lists.Add(wishList);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWishList), new { id = wishList.W_Id }, wishListDto);
    }

    // PUT: api/WishLists/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWishList(int id, Wish_ListDtos wishListDto)
    {
        if (id != wishListDto.W_Id)
        {
            return BadRequest();
        }

        var wishList = await _context.Wish_Lists.FindAsync(id);
        if (wishList == null)
        {
            return NotFound();
        }

        wishList.data = wishListDto.data;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WishListExists(id))
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

    // DELETE: api/WishLists/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishList(int id)
    {
        var wishList = await _context.Wish_Lists.FindAsync(id);
        if (wishList == null)
        {
            return NotFound();
        }

        _context.Wish_Lists.Remove(wishList);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WishListExists(int id)
    {
        return _context.Wish_Lists.Any(e => e.W_Id == id);
    }
}
