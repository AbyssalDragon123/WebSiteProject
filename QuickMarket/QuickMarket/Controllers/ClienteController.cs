using Microsoft.AspNetCore.Mvc;
using QuickMarket.Models;
using QuickMarket;
using Microsoft.EntityFrameworkCore;

namespace QuickMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly QuickMarketContext _context;

        public ClienteController(QuickMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var item = await _context.Clientes.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente item)
        {
            _context.Clientes.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.IdCliente }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente item)
        {
            if (id != item.IdCliente) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Clientes.FindAsync(id);
            if (item == null) return NotFound();
            _context.Clientes.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
