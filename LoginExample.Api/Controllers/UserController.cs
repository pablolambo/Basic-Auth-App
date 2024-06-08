namespace LoginExample.Api.Controllers;

using Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;

[Controller]
[Route("/api/account")]
public class UserController(IMediator mediator) : Controller
{
    private const string Username = "Paweł Frankowski";

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }

    [HttpGet("{guid:id}")]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var test = id;
        var newsletter = new User();
        
        return Ok(newsletter);
    }
}

