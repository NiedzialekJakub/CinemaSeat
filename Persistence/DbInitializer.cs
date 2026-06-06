using System;
using Domain;
using SQLitePCL;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if(context.Tickets.Any()) return;

        var ticketsList = new List<Ticket>();
        int seatsPerRow = 20;

        for(int row = 1; row <= 13; row++)
        {
            int sector;
            decimal price;

            if(row <= 2)
            {
                sector = 1;
                price = 18.00m;
            }else if(row <= 5)
            {
                sector = 2;
                price = 22.00m;
            }else if(row <= 8)
            {
                sector = 3;
                price = 26.00m;
            }else if(row <= 10)
            {
                sector = 4;
                price = 40.00m;
            }
            else
            {
                sector = 5;
                price = 30.00m;
            }

            for(int seat = 1; seat <= seatsPerRow; seat++)
            {
                ticketsList.Add(new Ticket
                {
                    Price = price,
                    BookingDate = DateTime.UtcNow,
                    Row = row,
                    SeatNumber = seat,
                    Sector = sector
                });
            }
        }

        context.Tickets.AddRange(ticketsList);
        await context.SaveChangesAsync();
    }
}