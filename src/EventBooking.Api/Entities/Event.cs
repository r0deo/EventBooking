namespace EventBooking.Api.Entities;

public class Event
{
    public Guid Id {get; set;}
    public Venue Venue {get; set;}
    public String Name {get; set;}
    public Guid VenueId {get; set;}
    public String Currency {get; set;}
    public DateTime StartDate {get; set;}
}