using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Api.Controllers;

[ApiController]
[Route("api")]
public class EventController : ControllerBase
{
    [HttpGet("EventList")]
    public ActionResult<List<EventListItem>> EventList()
    {
        var events = new List<EventListItem>();

        return Ok(events);
    }

    public class EventListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Venue { get; set; } = string.Empty;
    }
}
