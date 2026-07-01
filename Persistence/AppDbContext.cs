using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Ticket> Tickets {get; set;}
    public required DbSet<User> Users {get; set;}
    public required DbSet<Film> Films {get; set;}
}