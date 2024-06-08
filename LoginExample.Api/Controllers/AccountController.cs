namespace LoginExample.Api.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("account")]
public class AccountController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    ///
    /// <summary>Sign out a principal for the specified scheme.</summary>
    /// 
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await (_httpContextAccessor.HttpContext ?? throw new InvalidOperationException()).SignOutAsync(IdentityConstants.ApplicationScheme);
        _httpContextAccessor.HttpContext.Response.Redirect("/login");

        return Ok();
    }

    [HttpGet]
    [Route("id")]
    public async Task<ActionResult<string>> GetCurrentlyLoggedUserId()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User not authenticated or ID not found");
        }
        
        return Ok(userId);
    } 
    
    [HttpGet]
    [Route("email")]
    public async Task<ActionResult<string>> GetCurrentlyLoggedUsersEmail()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("User not authenticated or ID not found");
        }
        
        return Ok(email);
    }
}

