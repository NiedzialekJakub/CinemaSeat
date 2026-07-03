using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Users.Commands;

public class CreateUser
{
    public class Command : IRequest<string>
    {
        public required User User {get; set;}

        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Add(request.User);
                await context.SaveChangesAsync(cancellationToken);

                return request.User.Id;
            }
        }
    }
}