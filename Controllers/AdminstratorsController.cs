2using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize /*Role="Admin"*/]

public class AdminsController : ControllerBase
{
    private readonly E_ComerceContext _context;

    public AdminsController(E_ComerceContext context)
    {
        _context = context;
    }

    // GET: api/Admins
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdminDtos>>> GetAdmins()
    {
        var admins = await _context.Adminstrators.ToListAsync();

        var dtos = admins.Select(a => new AdminDtos
        {
            Admin_Id = a.Admin_Id,
            Admin_Name = a.Admin_Name,
            Admin_Type = a.Admin_Type,
            Admin_Email = a.Admin_Email,
            Admin_Password = a.Admin_Password
        }).ToList();

        return dtos;
    }

    // GET: api/Admins/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AdminDtos>> GetAdmin(int id)
    {
        var admin = await _context.Adminstrators.FindAsync(id);

        if (admin == null)
        {
            return NotFound();
        }

        var dto = new AdminDtos
        {
            Admin_Id = admin.Admin_Id,
            Admin_Name = admin.Admin_Name,
            Admin_Type = admin.Admin_Type,
            Admin_Email = admin.Admin_Email,
            Admin_Password = admin.Admin_Password
        };

        return dto;
    }

    // POST: api/Admins
    [HttpPost]
    public async Task<ActionResult<AdminDtos>> PostAdmin([FromForm]AdminDtos adminDto)
    {
        var admin = new Adminstrator
        {
           
            Admin_Name = adminDto.Admin_Name,
            Admin_Type = adminDto.Admin_Type,
            Admin_Email = adminDto.Admin_Email,
            Admin_Password = adminDto.Admin_Password
        };

        _context.Adminstrators.Add(admin);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAdmin), new { id = admin.Admin_Id }, adminDto);
    }

    // PUT: api/Admins/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdmin([FromForm]int id, AdminDtos adminDto)
    {
        if (id != adminDto.Admin_Id)
        {
            return BadRequest();
        }

        var admin = await _context.Adminstrators.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }
       
        admin.Admin_Name = adminDto.Admin_Name;
        admin.Admin_Type = adminDto.Admin_Type;
        admin.Admin_Email = adminDto.Admin_Email;
        admin.Admin_Password = adminDto.Admin_Password;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AdminExists(id))
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

    // DELETE: api/Admins/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var admin = await _context.Adminstrators.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }

        _context.Adminstrators.Remove(admin);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AdminExists(int id)
    {
        return _context.Adminstrators.Any(e => e.Admin_Id == id);
    }


   
}

