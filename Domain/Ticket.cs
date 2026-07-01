using System;
using System.Security;

namespace Domain;

public enum TicketStatus
{
    Free = 0,
    Reserved = 1,
    Confirmed = 2
}

public class Ticket
{
    public string Id {get; set;} = Guid.NewGuid().ToString();

    public string? UserId {get; set;}
    public int FilmId {get; set;}

    public decimal Price {get; set;}
    public TicketStatus Status {get; set;} = TicketStatus.Free;
    public DateTime BookingDate {get; set;}

    // location props
    public int SeatNumber {get; set;}
    public int Row {get; set;}
    public int Sector {get; set;}
}