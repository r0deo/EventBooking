using EventBooking.Api.Contracts;

namespace EventBooking.Api.Services;

public class InMemoryEventService : IEventService
{
    private readonly TimeProvider _timeProvider;

    private readonly IReadOnlyList<EventListItem> _events =
        new List<EventListItem>
        {
            new(
                Guid.Parse("64a48bf1-32b6-4726-a028-09b9831dd854"),
                "Baghdad Tech Meetup",
                new DateTime(2027, 1, 15, 15, 0, 0, DateTimeKind.Utc),
                "Baghdad Conference Hall"),
            new(
                Guid.Parse("23b03785-bca5-4073-866c-e593a480211d"),
                "Basra Music Night",
                new DateTime(2027, 2, 12, 17, 0, 0, DateTimeKind.Utc),
                "Basra Arts Center"),
            new(
                Guid.Parse("73914454-174a-4fe6-b20a-11a0e70cf008"),
                "Erbil Startup Forum",
                new DateTime(2027, 3, 5, 9, 0, 0, DateTimeKind.Utc),
                "Erbil Convention Center")
        }.AsReadOnly();

    public InMemoryEventService(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public IReadOnlyList<EventListItem> GetUpcoming()
    {
        var utcNow = _timeProvider.GetUtcNow().UtcDateTime;
        return _events.Where(e => e.Date > utcNow).ToArray();
    }

    public EventListItem? GetById(Guid id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }
}
