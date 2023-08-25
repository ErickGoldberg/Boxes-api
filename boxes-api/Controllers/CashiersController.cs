using boxes_api.Data;
using boxes_api.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace boxes_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashiersController : ControllerBase
    {
        private readonly BoxesContext _context;

        public CashiersController(BoxesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cashiers>>> GetCashiers()
        {
            return await _context.Cashiers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cashiers>> GetCashier(int id)
        {
            var cashier = await _context.Cashiers.FindAsync(id);

            if (cashier == null)
              return NotFound();
      
            return cashier;
        }

        [HttpPost]
        public async Task<ActionResult<Cashiers>> CreateCashier(Cashiers cashier)
        {
            _context.Cashiers.Add(cashier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashier", new { id = cashier.Id }, cashier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashier(int id, Cashiers cashier)
        {
            if (id != cashier.Id)
              return BadRequest();

            _context.Entry(cashier).State = EntityState.Modified; // sinaliza ao Entity Framework que esse objeto deve ser atualizado no banco de dados na próxima vez que SaveChangesAsync for chamado.

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cashiers.Any(e => e.Id == id))
                   return NotFound();

                   throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashier(int id)
        {
            var cashier = await _context.Cashiers.FindAsync(id);

            if (cashier == null)
                return NotFound();
            
            _context.Cashiers.Remove(cashier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
