using EventBooking.Api.Contracts;
using EventBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Api.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<EventListItem>> GetEvents()
    {
        var events = _eventService.GetUpcoming();
        return Ok(events);
    }

    // The guid constraint matches only route values that can be parsed as a Guid.
    [HttpGet("{id:guid}")]
    public ActionResult<EventListItem> GetEventById(Guid id)
    {
        var eventItem = _eventService.GetById(id);
        if (eventItem is null)
        {
            return NotFound();
        }

        return Ok(eventItem);
    }
}
