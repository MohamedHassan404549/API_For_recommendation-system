using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class BundleOrdersController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public BundleOrdersController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/BundleOrders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bundle_OrdersDtos>>> GetBundleOrders()
    {
        var bundleOrders = await _context.Bundle_Orders.ToListAsync();

        var dtos = bundleOrders.Select(bo => new Bundle_OrdersDtos
        {
            Order_status = bo.Order_status,
            data = bo.data,
            Bundle_Id = bo.Bundle_Id,
            Cus_Id = bo.Cus_Id
        }).ToList();

        return dtos;
    }

    // GET: api/BundleOrders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bundle_OrdersDtos>> GetBundleOrder(int id)
    {
        var bundleOrder = await _context.Bundle_Orders.FindAsync(id);

        if (bundleOrder == null)
        {
            return NotFound();
        }

        var dto = new Bundle_OrdersDtos
        {
            Order_status = bundleOrder.Order_status,
            data = bundleOrder.data,
            Bundle_Id = bundleOrder.Bundle_Id,
            Cus_Id = bundleOrder.Cus_Id
        };

        return dto;
    }

    // POST: api/BundleOrders
    [HttpPost]
    public async Task<ActionResult<Bundle_OrdersDtos>> PostBundleOrder([FromForm] Bundle_OrdersDtos bundleOrderDto)
    {
        var bundleOrder = new Bundle_Order
        {
            Order_status = bundleOrderDto.Order_status,
            data = bundleOrderDto.data,
            Bundle_Id = bundleOrderDto.Bundle_Id,
            Cus_Id = bundleOrderDto.Cus_Id
        };

        _context.Bundle_Orders.Add(bundleOrder);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBundleOrder), new { id = bundleOrder.B_Order_Id }, bundleOrderDto);
    }

    // PUT: api/BundleOrders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBundleOrder([FromForm] int id, Bundle_OrdersDtos bundleOrderDto)
    {
        if (id != bundleOrderDto.Bundle_Id)
        {
            return BadRequest();
        }

        var bundleOrder = new Bundle_Order
        {
            B_Order_Id = id,
            Order_status = bundleOrderDto.Order_status,
            data = bundleOrderDto.data,
            Bundle_Id = bundleOrderDto.Bundle_Id,
            Cus_Id = bundleOrderDto.Cus_Id
        };

        _context.Entry(bundleOrder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BundleOrderExists(id))
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

    // DELETE: api/BundleOrders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBundleOrder(int id)
    {
        var bundleOrder = await _context.Bundle_Orders.FindAsync(id);
        if (bundleOrder == null)
        {
            return NotFound();
        }

        _context.Bundle_Orders.Remove(bundleOrder);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BundleOrderExists(int id)
    {
        return _context.Bundle_Orders.Any(e => e.B_Order_Id == id);
    }
}
