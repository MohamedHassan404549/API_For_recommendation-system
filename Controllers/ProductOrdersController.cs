using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Authorize]

[Route("api/[controller]")]
[ApiController]
public class ProductOrdersController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public ProductOrdersController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/ProductOrders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_OrderDtos>>> GetProductOrders()
    {
        var productOrders = await _context.Product_Orders.ToListAsync();

        var dtos = productOrders.Select(po => new Product_OrderDtos
        {
            Order_status = po.Order_status,
            data = po.data,
            Cus_Id = po.Cus_Id,
            P_Id = po.P_Id
        }).ToList();

        return dtos;
    }

    // GET: api/ProductOrders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product_OrderDtos>> GetProductOrder(int id)
    {
        var productOrder = await _context.Product_Orders.FindAsync(id);

        if (productOrder == null)
        {
            return NotFound();
        }

        var dto = new Product_OrderDtos
        {
            Order_status = productOrder.Order_status,
            data = productOrder.data,
            Cus_Id = productOrder.Cus_Id,
            P_Id = productOrder.P_Id
        };

        return dto;
    }

    // POST: api/ProductOrders
    [HttpPost]
    public async Task<ActionResult<Product_OrderDtos>> PostProductOrder(Product_OrderDtos productOrderDto)
    {
        var productOrder = new Product_Order
        {
            Order_status = productOrderDto.Order_status,
            data = productOrderDto.data,
            Cus_Id = productOrderDto.Cus_Id,
            P_Id = productOrderDto.P_Id
        };

        _context.Product_Orders.Add(productOrder);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductOrder), new { id = productOrder.Order_Id }, productOrderDto);
    }

    // PUT: api/ProductOrders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductOrder(int id, Product_OrderDtos productOrderDto)
    {
        if (id != productOrderDto.Cus_Id || id != productOrderDto.P_Id)
        {
            return BadRequest();
        }

        var productOrder = await _context.Product_Orders.FindAsync(id);

        if (productOrder == null)
        {
            return NotFound();
        }

        productOrder.Order_status = productOrderDto.Order_status;
        productOrder.data = productOrderDto.data;
        productOrder.Cus_Id = productOrderDto.Cus_Id;
        productOrder.P_Id = productOrderDto.P_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductOrderExists(id))
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

    // DELETE: api/ProductOrders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductOrder(int id)
    {
        var productOrder = await _context.Product_Orders.FindAsync(id);
        if (productOrder == null)
        {
            return NotFound();
        }

        _context.Product_Orders.Remove(productOrder);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductOrderExists(int id)
    {
        return _context.Product_Orders.Any(e => e.Cus_Id == id || e.P_Id == id);
    }
}
