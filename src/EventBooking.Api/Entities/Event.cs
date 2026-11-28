namespace EventBooking.Api.Entities;

public class Event
{
    public Guid Id {get; set;}

    public required string Name {get; set;}
    public required string Currency {get; set;}
    public DateTimeOffset StarAt {get; set;}
    
    public Guid VenueId {get; set;}
    public Venue Venue {get; set;}
}