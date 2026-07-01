using System;
using System.Reflection.Metadata;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Films.Queries;

public class GetFilmsList
{
    public class Query : IRequest<List<Film>> {}

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Film>>
    {
        public async Task<List<Film>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Films.ToListAsync(cancellationToken);
        }
    }
}