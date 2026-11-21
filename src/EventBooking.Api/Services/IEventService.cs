using EventBooking.Api.Contracts;

namespace EventBooking.Api.Services;

public interface IEventService
{
    // Return only events whose start time is still in the future.
    IReadOnlyList<EventListItem> GetUpcoming();
    EventListItem? GetById(Guid id);
}
