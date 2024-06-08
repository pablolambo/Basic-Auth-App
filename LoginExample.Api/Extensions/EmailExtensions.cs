namespace LoginExample.Api.Extensions;

using System.Net.Mail;
using FluentEmail.Core.Interfaces;
using FluentEmail.Smtp;

public static class EmailExtensions
{
    public static void AddEmail(this IServiceCollection services, ConfigurationManager configuration)
    {
        var emailSettings = configuration.GetSection("EmailSettings");
        var defaultFromEmail = emailSettings["DefaultFromEmail"];
        var host = emailSettings["Host"];
        var port = emailSettings.GetValue<int>("Port");
        // Username and Password is empty because I’m using a local smtp server.
        services.AddFluentEmail(defaultFromEmail);
        services.AddSingleton<ISender>(x => new SmtpSender(new SmtpClient(host, port)));
    }
}