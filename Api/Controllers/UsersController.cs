using System;
using System.Text;
using Application.Users.Commands;
using Application.Users.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Controllers;

public class UsersController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await Mediator.Send(new GetUserList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(string id)
    {
        return await Mediator.Send(new GetUser.Query {UserId = id});
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateUser(User user)
    {
        return await Mediator.Send(new CreateUser.Command {User = user});
    }
}