using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistence;

namespace Application.Tickets.Queries;

public class GetTicketsToFilm
{
    public class Query : IRequest<List<Ticket>>
    {
        public int FilmId {get; set;}
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Ticket>>
    {
        public async Task<List<Ticket>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Tickets
                .Where(x => x.FilmId == request.FilmId)
                .ToListAsync(cancellationToken);
        }
    }
}
