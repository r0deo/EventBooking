using EventBooking.Api.Contracts;

namespace EventBooking.Api.Services;

public interface IEventService
{
    IReadOnlyList<EventListItem> GetAll();
    EventListItem? GetById(Guid id);
}
