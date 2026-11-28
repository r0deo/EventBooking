namespace EventBooking.Api.Entities;

public class Venue
{
   public Guid Id {get; set;}
   public string Name {get; set;}
   public string Location {get; set;}
   public int Capacity {get; set;}
   public List <Event> Events {get; set;}
   public List <Seat> Seats {get; set;}

}