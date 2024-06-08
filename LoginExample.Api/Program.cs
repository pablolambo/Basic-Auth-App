using System.Security.Claims;
using LoginExample.Api.Config;
using LoginExample.Api.Database;
using LoginExample.Api.Extensions;
using LoginExample.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddCustomServices();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthorization();
services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);   

services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AuthContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.ApplyMigrations();
}

app.MapGet("users/me", async (ClaimsPrincipal claims, AuthContext context) =>
{
    var userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

    return await context.Users.FindAsync(userId);
}).RequireAuthorization();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapIdentityApi<User>();

app.Run();