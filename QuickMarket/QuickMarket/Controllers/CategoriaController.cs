using Microsoft.AspNetCore.Mvc;
using QuickMarket.Models;
using QuickMarket;
using Microsoft.EntityFrameworkCore;

namespace QuickMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly QuickMarketContext _context;

        public CategoriaController(QuickMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            var item = await _context.Categorias.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Create(Categoria item)
        {
            _context.Categorias.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.IdCategoria }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Categoria item)
        {
            if (id != item.IdCategoria) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Categorias.FindAsync(id);
            if (item == null) return NotFound();
            _context.Categorias.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
