namespace EventBooking.Api.Entities;


public class Seat
{
    public Guid Id {get; set;}

    public required string Label {get; set;} 

    public Venue Venue {get; set;} = null!;
    public Guid VenueId {get; set;}
}