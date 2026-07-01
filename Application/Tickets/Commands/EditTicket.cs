using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Tickets.Commands;

public class EditTicket
{
    public class Command : IRequest
    {
        public required Ticket Ticket {get; set;}
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var ticket = await context.Tickets.FindAsync([request.Ticket.Id], cancellationToken)
                ?? throw new Exception("Cannot find activity");
                
            ticket.UserId = request.Ticket.UserId;
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}