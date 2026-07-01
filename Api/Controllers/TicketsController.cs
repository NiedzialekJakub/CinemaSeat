using System;
using Api.Controllers;
using Application.Tickets.Queries;
using Application.Tickets.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers;
public class TicketsController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Ticket>>> GetTickets()
    {
        return await Mediator.Send(new GetTicketList.Query());
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<List<Ticket>>> GetTicketsToUser(string userId)
    {
        return await Mediator.Send(new GetTicketsToUser.Query {UserId = userId});
    }

    [HttpGet("film/{filmId}")]
    public async Task<ActionResult<List<Ticket>>> GetTicketsToFilm(int filmId)
    {
        return await Mediator.Send(new GetTicketsToFilm.Query {FilmId = filmId});
    }

    [HttpPut]
    public async Task<ActionResult> EditTicketUserId(Ticket ticket)
    {
        await Mediator.Send(new EditTicket.Command {Ticket = ticket});

        return NoContent();
    }
}