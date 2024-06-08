namespace LoginExample.Api.Database;

using Microsoft.EntityFrameworkCore;
using Models;

public class AuthContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<User> Users { get; set; }

    public AuthContext(DbContextOptions<AuthContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
}