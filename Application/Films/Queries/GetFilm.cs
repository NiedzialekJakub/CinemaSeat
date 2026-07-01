using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Films.Queries;

public class GetFilm
{
    public class Query : IRequest<Film>
    {
        public int Id {get; set;}
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Film>
    {
        public async Task<Film> Handle(Query request, CancellationToken cancellationToken)
        {
            var film = await context.Films.FindAsync([request.Id], cancellationToken);

            if(film == null) throw new Exception("Film not found");
            return film;
        }
    }
}