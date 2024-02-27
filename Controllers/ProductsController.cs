using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using مشروع_التخرج.Dtos;
using Microsoft.AspNetCore.Authorization;
using Humanizer;

namespace مشروع_التخرج.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly E_ComerceContext _context;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 2097152;

        public ProductsController(E_ComerceContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm] ProductDtos productDto)
        {
            if (productDto.p_Image == null)
                return BadRequest("poster is required");

            if (!_allowedExtenstions.Contains(Path.GetExtension(productDto.p_Image.FileName).ToLower()))
                return BadRequest("only .png and .jpg!");

            if (productDto.p_Image.Length > _maxAllowedPosterSize)
                return BadRequest("MAx Allowed Size is 2MB!");

            using var dateStream = new MemoryStream();
            await productDto.p_Image.CopyToAsync(dateStream);
            var product = new Product
            {
                P_Name = productDto.P_Name,
                P_Description = productDto.P_Description,
                p_Image = dateStream.ToArray(),
                P_Price = productDto.P_Price,
                P_Quantity = productDto.P_Quantity,
                Admin_Id = productDto.Admin_Id,
                Sub_C_Id=productDto.Sub_C_Id
                
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.P_Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromForm] int id, ProductDtos productDto)
        {
            //if (id != productDto.P_Id)
            //{
            //    return BadRequest();
            //}

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            if (productDto.p_Image != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(productDto.p_Image.FileName).ToLower()))
                    return BadRequest("only .png and .jpg!");

                if (productDto.p_Image.Length > _maxAllowedPosterSize)
                    return BadRequest("Max Allowed Size is 2MB!");

                using var memoryStream = new MemoryStream();
                await productDto.p_Image.CopyToAsync(memoryStream);
                product.p_Image = memoryStream.ToArray();
            }

            product.P_Name = productDto.P_Name;
            product.P_Description = productDto.P_Description;
            product.P_Price = productDto.P_Price;
            product.P_Quantity = productDto.P_Quantity;
            product.Admin_Id = productDto.Admin_Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.P_Id == id);
        }
    }
}
