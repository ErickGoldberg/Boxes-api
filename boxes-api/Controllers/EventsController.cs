using boxes_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace boxes_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // "/api/events"
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event>();

        [HttpGet]
        public ActionResult<IQueryable<Event>> GetEvents()
        {
            var query = events.AsQueryable();
            return Ok(query);
        }

        [HttpGet("{id}")] //"/api/events/1"
        public ActionResult<IQueryable<Event>> GetEventsById(int id)
        {
            var _event = events.FirstOrDefault(e => e.Id == id);

            if (_event == null)
                return NotFound();

            return Ok(_event);
        }

        [HttpPost]
        public ActionResult AddEvents(Event _event)
        {
            events.Add(_event);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult PutEvents(int id, Event eventUpdated)
        {
            var _event = events.FirstOrDefault(_e => _e.Id == id);

            if (_event == null)
                return NotFound();

            _event.HeadNumber = eventUpdated.HeadNumber;
            _event.Name = eventUpdated.Name;
            _event.Date = eventUpdated.Date;
            _event.Payment = eventUpdated.Payment;
            _event.Comission = eventUpdated.Comission;
            _event.Security = eventUpdated.Security;
            _event.Bar = eventUpdated.Bar;
            _event.Place = eventUpdated.Place;
            _event.Address = eventUpdated.Address;
            _event.Number = eventUpdated.Number;
            _event.Neighboorhood = eventUpdated.Neighboorhood;
            _event.City = eventUpdated.City;
            _event.State = eventUpdated.State;
            _event.Cep = eventUpdated.Cep;
            _event.UpdatedAt = DateTime.UtcNow;
            //_event.CreatedAt = eventUpdated.CreatedAt; Não precisa porque vai ser DateTime.Now(Imutável)
            // Não usei reflection(mais conciso e genérico) para ter uma performance melhor

            return Ok(_event);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvents(int id)
        {
            var _event = events.FirstOrDefault(_e => _e.Id == id);

            if (_event == null)
                return NotFound();

            events.Remove(_event);
            return NoContent();
        }
    }

}
