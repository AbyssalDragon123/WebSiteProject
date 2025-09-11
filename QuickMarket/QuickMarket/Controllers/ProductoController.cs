using Microsoft.AspNetCore.Mvc;
using QuickMarket.Models;
using QuickMarket;
using Microsoft.EntityFrameworkCore;

namespace QuickMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly QuickMarketContext _context;

        public ProductoController(QuickMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var item = await _context.Productos.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Create(Producto item)
        {
            _context.Productos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.IdProducto }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto item)
        {
            if (id != item.IdProducto) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Productos.FindAsync(id);
            if (item == null) return NotFound();
            _context.Productos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
