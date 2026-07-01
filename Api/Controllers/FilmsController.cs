using Application.Films.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers;

public class FilmsController(): BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Film>>> GetFilms()
    {
        return await Mediator.Send(new GetFilmsList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Film>> GetFilm(int id)
    {
        return await Mediator.Send(new GetFilm.Query {Id = id});
    }
}