using EventBooking.Api.Services;
using Microsoft.Extensions.Time.Testing;

namespace EventBooking.Api.Tests;

public class InMemoryEventServiceTests
{
    [Fact]
    public void GetUpcoming_OnFebruaryFirst2027_ReturnsTwoEvents()
    {
        var clock = new FakeTimeProvider(new DateTimeOffset(2027, 2, 1, 0, 0, 0, TimeSpan.Zero));
        var service = new InMemoryEventService(clock);

        var events = service.GetUpcoming();

        Assert.Equal(2, events.Count);
    }

    [Fact]
    public void GetById_WithUnknownId_ReturnsNull()
    {
        var clock = new FakeTimeProvider(new DateTimeOffset(2027, 2, 1, 0, 0, 0, TimeSpan.Zero));
        var service = new InMemoryEventService(clock);
        var unknownId = Guid.Parse("d4a420ac-b0c0-4a36-a90f-571f876c0933");

        var eventItem = service.GetById(unknownId);

        Assert.Null(eventItem);
    }
}
