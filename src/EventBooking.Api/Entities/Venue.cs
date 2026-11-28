namespace EventBooking.Api.Entities;

public class Venue
{
   public Guid Id {get; set;}

   public required string Name {get; set;}
   public required string Location {get; set;}
   public int Capacity {get; set;}

   public List <Event> Events {get; set;} = null!;
   public List <Seat> Seats {get; set;} = null!;

}