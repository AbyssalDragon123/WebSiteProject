using Microsoft.AspNetCore.Mvc;
using QuickMarket.Models;
using QuickMarket;
using Microsoft.EntityFrameworkCore;

namespace QuickMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly QuickMarketContext _context;

        public VentaController(QuickMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetAll()
        {
            return await _context.Ventas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetById(int id)
        {
            var item = await _context.Ventas.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> Create(Venta item)
        {
            item.Fecha = DateTime.UtcNow;
            _context.Ventas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.IdVenta }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Venta item)
        {
            if (id != item.IdVenta) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Ventas.FindAsync(id);
            if (item == null) return NotFound();
            _context.Ventas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
