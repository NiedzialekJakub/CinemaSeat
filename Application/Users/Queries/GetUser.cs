using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Users.Queries;

public class GetUser
{
    public class Query : IRequest<User>
    {
        public required string UserId {get; set;}
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, User>
    {
        public async Task<User> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([request.UserId], cancellationToken);

            if(user == null) throw new Exception("user not found");
            return user;
        }
    }
}