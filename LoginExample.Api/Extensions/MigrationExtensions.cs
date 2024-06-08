namespace LoginExample.Api.Extensions;

using Database;
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