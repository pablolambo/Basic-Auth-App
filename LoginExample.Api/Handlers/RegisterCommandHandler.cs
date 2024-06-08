namespace LoginExample.Api.Handlers;

using MediatR;

public sealed record RegisterCommand : IRequest<Unit>
{
    public required string Username { get; init; } 
    public required string Password { get; init; } 
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    public Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}