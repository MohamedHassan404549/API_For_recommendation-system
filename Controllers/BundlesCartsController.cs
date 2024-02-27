using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using مشروع_التخرج.Dtos;
using مشروع_التخرج.Models;

namespace مشروع_التخرج.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BundleCartsController : ControllerBase
    {
        private readonly E_ComerceContext _context;

        public BundleCartsController(E_ComerceContext context)
        {
            _context = context;
        }

        // GET: api/BundleCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bundle_CartDtos>>> GetBundleCarts()
        {
            var bundleCarts = await _context.Bundle_Carts
                .Select(bc => new Bundle_CartDtos
                {
                    Bundle_Id = bc.Bundle_Id,
                    Cart_Id = bc.Cart_Id
                })
                .ToListAsync();

            return bundleCarts;
        }

        // GET: api/BundleCarts/5_5 (where 5 is Bundle_Id and 5 is Cart_Id)
        [HttpGet("{bundleId}_{cartId}")]
        public async Task<ActionResult<Bundle_CartDtos>> GetBundleCart(int bundleId, int cartId)
        {
            var bundleCart = await _context.Bundle_Carts
                .Where(bc => bc.Bundle_Id == bundleId && bc.Cart_Id == cartId)
                .Select(bc => new Bundle_CartDtos
                {
                    Bundle_Id = bc.Bundle_Id,
                    Cart_Id = bc.Cart_Id
                })
                .FirstOrDefaultAsync();

            if (bundleCart == null)
            {
                return NotFound();
            }

            return bundleCart;
        }

        // POST: api/BundleCarts
        [HttpPost]
        public async Task<ActionResult<Bundle_CartDtos>> PostBundleCart(Bundle_CartDtos bundleCartDtos)
        {
            var bundleCart = new Bundle_Cart
            {
                Bundle_Id = bundleCartDtos.Bundle_Id,
                Cart_Id = bundleCartDtos.Cart_Id
            };

            _context.Bundle_Carts.Add(bundleCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBundleCart", new { bundleId = bundleCart.Bundle_Id, cartId = bundleCart.Cart_Id }, bundleCartDtos);
        }

        // DELETE: api/BundleCarts/5_5 (where 5 is Bundle_Id and 5 is Cart_Id)
        [HttpDelete("{bundleId}_{cartId}")]
        public async Task<IActionResult> DeleteBundleCart(int bundleId, int cartId)
        {
            var bundleCart = await _context.Bundle_Carts.FindAsync(bundleId, cartId);
            if (bundleCart == null)
            {
                return NotFound();
            }

            _context.Bundle_Carts.Remove(bundleCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BundleCartExists(int bundleId, int cartId)
        {
            return _context.Bundle_Carts.Any(bc => bc.Bundle_Id == bundleId && bc.Cart_Id == cartId);
        }
    }
}
