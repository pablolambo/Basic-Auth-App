namespace BasicAuthApp.Api.Extensions;

using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var context = scope.ServiceProvider.GetRequiredService<AuthContext>();

        context.Database.Migrate();
    }
}