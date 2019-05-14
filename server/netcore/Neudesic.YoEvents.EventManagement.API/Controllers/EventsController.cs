using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neudesic.YoEvents.EventManagement.Application.Interfaces;
using Neudesic.YoEvents.EventManagement.Application.Models;

namespace Neudesic.YoEvents.EventManagement.API.Controllers
{
    public class EventsController : BaseApiController
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = await eventService.GetAllEvents();
            return Ok(items);
        }

        // GET: api/Events/0E5E8F6E-3554-48B2-96FC-AEA573DE7E3D
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await eventService.GetEventDetails(id);
            return Ok(item);
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventViewModel item)
        {
            var e = await eventService.CreateEvent(item);
            return Created("api/event", new { id = e });
        }

        //// PUT: api/Events/5
        //[HttpPut("{id}")]
        //public IActionResult Put(long id, [FromBody] EventDTO item)
        //{
        //    var eventItem = repository.GetById<Event>(id);
        //    repository.Update(eventItem);

        //    return Ok(EventDTO.FromEvent(eventItem));
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(long id)
        //{
        //    var eventItem = repository.GetById<Event>(id);
        //    repository.Delete(eventItem);
        //}
    }
}
