using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using boxes_api.Data; // Certifique-se de incluir o namespace onde o contexto e a entidade do banco de dados estão definidos
using boxes_api.DbConnection;

namespace boxes_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly BoxesContext _context;

        public EventsController(BoxesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<Event>>> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IQueryable<Event>>> GetEventById(int id)
        {
            var _event = await _context.Events.FindAsync(id);

            if (_event == null)
              return NotFound();

            return Ok(_event);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(Event _event)
        {
            _context.Events.Add(_event);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEvent(int id, Event eventUpdated)
        {
            var _event = await _context.Events.FindAsync(id);

            if (_event == null)
              return NotFound();

            await _context.SaveChangesAsync();

            return Ok(_event);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var _event = await _context.Events.FindAsync(id);

            if (_event == null)
              return NotFound();

            _context.Events.Remove(_event);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
