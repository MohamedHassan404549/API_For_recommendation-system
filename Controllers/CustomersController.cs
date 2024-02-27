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
public class CustomersController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public CustomersController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/Customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDtos>>> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();

        var dtos = customers.Select(c => new CustomerDtos
        {
            Cus_Id = c.Cus_Id,
            Cus_firstName = c.Cus_firstName,
            Cus_lastName = c.Cus_lastName,
            Cus_phone = c.Cus_phone,
            Cus_Email = c.Cus_Email,
            Cus_Passaword = c.Cus_Passaword,
            Cus_Country = c.Cus_Country,
            Cus_City = c.Cus_City,
            Cus_Street = c.Cus_Street,
            Cart_Id = c.Cart_Id,
            W_Id = c.W_Id
        }).ToList();

        return dtos;
    }

    // GET: api/Customers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDtos>> GetCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        var dto = new CustomerDtos
        {
            Cus_Id = customer.Cus_Id,
            Cus_firstName = customer.Cus_firstName,
            Cus_lastName = customer.Cus_lastName,
            Cus_phone = customer.Cus_phone,
            Cus_Email = customer.Cus_Email,
            Cus_Passaword = customer.Cus_Passaword,
            Cus_Country = customer.Cus_Country,
            Cus_City = customer.Cus_City,
            Cus_Street = customer.Cus_Street,
            Cart_Id = customer.Cart_Id,
            W_Id = customer.W_Id
        };

        return dto;
    }

    // POST: api/Customers
    [HttpPost]
    public async Task<ActionResult<CustomerDtos>> PostCustomer(CustomerDtos customerDto)
    {
        var customer = new Customer
        {
            Cus_firstName = customerDto.Cus_firstName,
            Cus_lastName = customerDto.Cus_lastName,
            Cus_phone = customerDto.Cus_phone,
            Cus_Email = customerDto.Cus_Email,
            Cus_Passaword = customerDto.Cus_Passaword,
            Cus_Country = customerDto.Cus_Country,
            Cus_City = customerDto.Cus_City,
            Cus_Street = customerDto.Cus_Street,
            Cart_Id = customerDto.Cart_Id,
            W_Id = customerDto.W_Id
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Cus_Id }, customerDto);
    }

    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, CustomerDtos customerDto)
    {
        if (id != customerDto.Cus_Id)
        {
            return BadRequest();
        }

        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        customer.Cus_firstName = customerDto.Cus_firstName;
        customer.Cus_lastName = customerDto.Cus_lastName;
        customer.Cus_phone = customerDto.Cus_phone;
        customer.Cus_Email = customerDto.Cus_Email;
        customer.Cus_Passaword = customerDto.Cus_Passaword;
        customer.Cus_Country = customerDto.Cus_Country;
        customer.Cus_City = customerDto.Cus_City;
        customer.Cus_Street = customerDto.Cus_Street;
        customer.Cart_Id = customerDto.Cart_Id;
        customer.W_Id = customerDto.W_Id;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
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

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.Cus_Id == id);
    }
}
