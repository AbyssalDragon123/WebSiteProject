using Microsoft.AspNetCore.Mvc;
using QuickMarket.Models;
using QuickMarket;
using Microsoft.EntityFrameworkCore;

namespace QuickMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : ControllerBase
    {
        private readonly QuickMarketContext _context;

        public DetalleVentaController(QuickMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetAll()
        {
            return await _context.DetalleVentas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> GetById(int id)
        {
            var item = await _context.DetalleVentas.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> Create(DetalleVenta item)
        {
            _context.DetalleVentas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.IdDetalle }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DetalleVenta item)
        {
            if (id != item.IdDetalle) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.DetalleVentas.FindAsync(id);
            if (item == null) return NotFound();
            _context.DetalleVentas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
