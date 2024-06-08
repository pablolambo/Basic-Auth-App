namespace LoginExample.Api.Config;

using MediatR;

public static class DependencyInjection
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program));
    }
}