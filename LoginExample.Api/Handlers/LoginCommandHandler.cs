namespace LoginExample.Api.Handlers;

using MediatR;

public sealed record LoginCommand : IRequest<Unit>
{
    public required string Username { get; init; } 
    public required string Password { get; init; } 
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
{
    public Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}