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
                Title = "Avatar",
                Date = new DateTime(2026, 7, 1, 15, 0, 0),
                ScreeningRoom = 1,
                Category = "Sci-Fi",
                Description = "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home."
            },
            new Film
            {
                Id = 2,
                Title = "Avatar: The Way of Water",
                Date = new DateTime(2026, 7, 1, 19, 0, 0),
                ScreeningRoom = 1,
                Category = "Sci-Fi",
                Description = "Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na'vi race to protect their home."
            },
            new Film
            {
                Id = 3,
                Title = "Star Wars: The Force Awakens",
                Date = new DateTime(2026, 7, 2, 16, 0, 0),
                ScreeningRoom = 2,
                Category = "Sci-Fi",
                Description = "As a new threat to the galaxy rises, Rey, a desert scavenger, and Finn, an ex-stormtrooper, must join Han Solo and Chewbacca to search for the one hope of restoring peace."
            },
            new Film
            {
                Id = 4,
                Title = "Jurassic World",
                Date = new DateTime(2026, 7, 3, 18, 30, 0),
                ScreeningRoom = 1,
                Category = "Sci-Fi",
                Description = "A new theme park, built on the original site of Jurassic Park, creates a genetically modified hybrid dinosaur, the Indominus Rex, which escapes containment and goes on a killing spree."
            },

            //Action
            new Film
            {
                Id = 5,
                Title = "Avengers: Endgame",
                Date = new DateTime(2026, 7, 2, 19, 30, 0),
                ScreeningRoom = 1,
                Category = "Action",
                Description = "After the devastating events of Avengers: Wojna bez granic (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe."
            },
            new Film
            {
                Id = 6,
                Title = "Avengers: Infinity War",
                Date = new DateTime(2026, 7, 3, 15, 0, 0),
                ScreeningRoom = 2,
                Category = "Action",
                Description = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe."
            },
            new Film
            {
                Id = 7,
                Title = "The Avengers",
                Date = new DateTime(2026, 7, 4, 17, 0, 0),
                ScreeningRoom = 1,
                Category = "Action",
                Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity."
            },
            new Film
            {
                Id = 8,
                Title = "Furious 7",
                Date = new DateTime(2026, 7, 4, 21, 0, 0),
                ScreeningRoom = 3,
                Category = "Action",
                Description = "Deckard Shaw seeks revenge against Dominic Toretto and his family for his comatose brother."
            },
            new Film
            {
                Id = 9,
                Title = "Top Gun: Maverick",
                Date = new DateTime(2026, 7, 5, 20, 0, 0),
                ScreeningRoom = 2,
                Category = "Action",
                Description = "The story involves Maverick confronting his past while training a group of younger Top Gun graduates, including the son of his deceased best friend, for a dangerous mission."
            },

            //Fantasy
            new Film
            {
                Id = 10,
                Title = "The Hobbit: The Battle of the Five Armies",
                Date = new DateTime(2026, 7, 5, 14, 0, 0),
                ScreeningRoom = 3,
                Category = "Fantasy",
                Description = "Bilbo Baggins and company are forced to engage in a war against an array of combatants and keep the Lonely Mountain from falling into the hands of a rising darkness."
            },
            new Film
            {
                Id = 11,
                Title = "Inside Out 2",
                Date = new DateTime(2026, 7, 2, 14, 0, 0),
                ScreeningRoom = 3,
                Category = "Animated",
                Description = "A sequel that features Riley entering puberty and experiencing brand new, more complex emotions as a result. As Riley tries to adapt to her teenage years, her old emotions try to adapt to the possibility of being replaced."
            },
            new Film
            {
                Id = 12,
                Title = "The Lord of the Rings: The Return of the King",
                Date = new DateTime(2026, 7, 6, 18, 0, 0),
                ScreeningRoom = 1,
                Category = "Fantasy",
                Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring."
            },
            //Animated

            new Film
            {
                Id = 13,
                Title = "The Lion King",
                Date = new DateTime(2026, 7, 3, 11, 0, 0),
                ScreeningRoom = 3,
                Category = "Animated",
                Description = "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself."
            },

            new Film
            {
                Id = 14,
                Title = "The Super Mario Bros. Movie",
                Date = new DateTime(2026, 7, 4, 13, 0, 0),
                ScreeningRoom = 2,
                Category = "Animated",
                Description = "Brooklyn plumbers Mario and Luigi are warped to the magical Mushroom Kingdom, and Mario must team up with Princess Peach, Toad, and Donkey Kong to save Luigi from the evil Bowser."
            },

            //Drama
            new Film
            {
                Id = 15,
                Title = "Titanic",
                Date = new DateTime(2026, 7, 1, 20, 0, 0),
                ScreeningRoom = 2,
                Category = "Drama",
                Description = "A young aristocrat falls in love with a poor artist aboard the luxurious, ill-fated RMS Titanic."
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