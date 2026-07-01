using System;
using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Tickets.Queries;

public class GetTicketsToUser
{

    public class Query : IRequest<List<Ticket>>
    {
        public required string UserId {get; set;}        
    }


    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Ticket>>
    {
        public async Task<List<Ticket>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Tickets
                .Where(x => x.UserId == request.UserId)
                .ToListAsync(cancellationToken);
        }
    }
}