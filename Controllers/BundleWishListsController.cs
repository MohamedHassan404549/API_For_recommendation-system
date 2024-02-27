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

public class BundleWishListsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public BundleWishListsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/BundleWishLists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bundle_Wish_ListDtos>>> GetBundleWishLists()
    {
        var bundleWishLists = await _context.Bundle_Wish_Lists.ToListAsync();

        var dtos = bundleWishLists.Select(bwl => new Bundle_Wish_ListDtos
        {
            W_Id = bwl.W_Id,
            Bundle_Id = bwl.Bundle_Id
        }).ToList();

        return dtos;
    }

    // GET: api/BundleWishLists/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bundle_Wish_ListDtos>> GetBundleWishList(int id)
    {
        var bundleWishList = await _context.Bundle_Wish_Lists.FindAsync(id);

        if (bundleWishList == null)
        {
            return NotFound();
        }

        var dto = new Bundle_Wish_ListDtos
        {
            W_Id = bundleWishList.W_Id,
            Bundle_Id = bundleWishList.Bundle_Id
        };

        return dto;
    }

    // POST: api/BundleWishLists
    [HttpPost]
    public async Task<ActionResult<Bundle_Wish_ListDtos>> PostBundleWishList(Bundle_Wish_ListDtos bundleWishListDto)
    {
        var bundleWishList = new Bundle_Wish_List
        {
            W_Id = bundleWishListDto.W_Id,
            Bundle_Id = bundleWishListDto.Bundle_Id
        };

        _context.Bundle_Wish_Lists.Add(bundleWishList);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBundleWishList), new { id = bundleWishList.W_Id }, bundleWishListDto);
    }

    // PUT: api/BundleWishLists/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBundleWishList(int id, Bundle_Wish_ListDtos bundleWishListDto)
    {
        if (id != bundleWishListDto.W_Id || id != bundleWishListDto.Bundle_Id)
        {
            return BadRequest();
        }

        var bundleWishList = await _context.Bundle_Wish_Lists.FindAsync(id);

        if (bundleWishList == null)
        {
            return NotFound();
        }

        bundleWishList.W_Id = bundleWishListDto.W_Id;
        bundleWishList.Bundle_Id = bundleWishListDto.Bundle_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BundleWishListExists(id))
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

    // DELETE: api/BundleWishLists/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBundleWishList(int id)
    {
        var bundleWishList = await _context.Bundle_Wish_Lists.FindAsync(id);
        if (bundleWishList == null)
        {
            return NotFound();
        }

        _context.Bundle_Wish_Lists.Remove(bundleWishList);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BundleWishListExists(int id)
    {
        return _context.Bundle_Wish_Lists.Any(e => e.W_Id == id);
    }
}
