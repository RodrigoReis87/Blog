using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    // Esse trecho de código é a mesma coisa que o parâmetro FromServices da linha 18
    // private readonly TokenService _tokenService;
    //
    // public AcountController(TokenService tokenService)
    // {
    //     _tokenService = tokenService;
    // }
    
    [HttpPost("v1/login")]
    public IActionResult Login([FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);

        return Ok(token);
    }
    
    [Authorize (Roles = "user")]
    [HttpGet("v1/user")]
    public IActionResult GetUser() => Ok(User.Identity.Name);
    
    [Authorize (Roles = "author")]
    [HttpGet("v1/author")]
    public IActionResult GetAuthor() => Ok(User.Identity.Name);
    
    [Authorize (Roles = "admins")]
    [HttpGet("v1/admin")]
    public IActionResult GetAdmin() => Ok(User.Identity.Name);
}