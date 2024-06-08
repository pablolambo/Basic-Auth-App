namespace LoginExample.Api.Database;

using Microsoft.EntityFrameworkCore;
using Models;

public class AuthContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}