namespace EventBooking.Api.Contracts;

public record EventListItem(Guid Id, string Name, DateTime Date, string Venue);
