using System;
using Domain;
using SQLitePCL;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if(context.Films.Any()) return;

        var usersList = new List<User>();
        var ticketsList = new List<Ticket>();
        int seatsPerRow = 20;
        int numberFilms = 15;

        usersList.Add(new User
        {
            Name = "Test",
            Email = "test@test.pl",
            Password = "Test"
        });

        var films = new List<Film>
        {
            //Sci-Fi
            new Film
            {
                Id = 1,
                Name = "Avatar",
                Date = new DateTime(2026, 7, 1, 15, 0, 0),
                ScreeningRoom = 1,
                Category = "Sci-Fi"
            },
            new Film
            {
                Id = 2,
                Name = "Avatar: The Way of Water",
                Date = new DateTime(2026, 7, 1, 19, 0, 0),
                ScreeningRoom = 1,
                Category = "Sci-Fi"
            },
            new Film
            {
                Id = 3,
                Name = "Star Wars: The Force Awakens",
                Date = new DateTime(2026, 7, 2, 16, 0, 0),
                ScreeningRoom = 2,
                Category = "Sci-Fi"
            },
            new Film
            {
                Id = 4,
                Name = "Jurassic World",
                Date = new DateTime(2026, 7, 3, 18, 30, 0),
                ScreeningRoom = 1,
                Category = "Sci-Fi"
            },

            //Action
            new Film
            {
                Id = 5,
                Name = "Avengers: Endgame",
                Date = new DateTime(2026, 7, 2, 19, 30, 0),
                ScreeningRoom = 1,
                Category = "Action"
            },
            new Film
            {
                Id = 6,
                Name = "Avengers: Infinity War",
                Date = new DateTime(2026, 7, 3, 15, 0, 0),
                ScreeningRoom = 2,
                Category = "Action"
            },
            new Film
            {
                Id = 7,
                Name = "The Avengers",
                Date = new DateTime(2026, 7, 4, 17, 0, 0),
                ScreeningRoom = 1,
                Category = "Action"
            },
            new Film
            {
                Id = 8,
                Name = "Furious 7",
                Date = new DateTime(2026, 7, 4, 21, 0, 0),
                ScreeningRoom = 3,
                Category = "Action"
            },
            new Film
            {
                Id = 9,
                Name = "Top Gun: Maverick",
                Date = new DateTime(2026, 7, 5, 20, 0, 0),
                ScreeningRoom = 2,
                Category = "Action"
            },

            //Fantasy
            new Film
            {
                Id = 10,
                Name = "Ne Zha 2",
                Date = new DateTime(2026, 7, 5, 14, 0, 0),
                ScreeningRoom = 3,
                Category = "Fantasy"
            },
            new Film
            {
                Id = 11,
                Name = "Inside Out 2",
                Date = new DateTime(2026, 7, 2, 14, 0, 0),
                ScreeningRoom = 3,
                Category = "Fantasy"
            },
            new Film
            {
                Id = 12,
                Name = "The Lord of the Rings: The Return of the King",
                Date = new DateTime(2026, 7, 6, 18, 0, 0),
                ScreeningRoom = 1,
                Category = "Fantasy"
            },
            //Animated

            new Film
            {
                Id = 13,
                Name = "The Lion King",
                Date = new DateTime(2026, 7, 3, 11, 0, 0),
                ScreeningRoom = 3,
                Category = "Animated"
            },

            new Film
            {
                Id = 14,
                Name = "The Super Mario Bros. Movie",
                Date = new DateTime(2026, 7, 4, 13, 0, 0),
                ScreeningRoom = 2,
                Category = "Animated"
            },

            //Drama
            new Film
            {
                Id = 15,
                Name = "Titanic",
                Date = new DateTime(2026, 7, 1, 20, 0, 0),
                ScreeningRoom = 2,
                Category = "Drama"
            }
        };



        for(int i = 1; i <= numberFilms; i++)
        {
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
                        FilmId = i,
                        Price = price,
                        BookingDate = DateTime.UtcNow,
                        Row = row,
                        SeatNumber = seat,
                        Sector = sector
                    });
                }
            }            
        }


        context.Tickets.AddRange(ticketsList);
        context.Users.AddRange(usersList);
        context.Films.AddRange(films);
        await context.SaveChangesAsync();
    }
}