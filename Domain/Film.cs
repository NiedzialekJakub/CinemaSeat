using System;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Film
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public DateTime Date {get; set;}
    public int ScreeningRoom {get; set;}
    public required string Category {get; set;}
}