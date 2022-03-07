using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
public class AcountController : ControllerBase
{
    // Esse trecho de código é a mesma coisa que o parâmetro FromServices da linha 18
    // private readonly TokenService _tokenService;
    //
    // public AcountController(TokenService tokenService)
    // {
    //     _tokenService = tokenService;
    // }
    
    [HttpPost("v1 / login")]
    public IActionResult Login([FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);

        return Ok(token);
    }
}