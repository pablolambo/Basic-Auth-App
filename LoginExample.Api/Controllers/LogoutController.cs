namespace LoginExample.Api.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class LogoutController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogoutController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    [Route("/logout")]
    public async Task<IActionResult> Logout()
    {
        if (_httpContextAccessor.HttpContext == null) return BadRequest("NULL");
        
        await _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        _httpContextAccessor.HttpContext.Response.Redirect("/login");

        return Ok();
    }
}