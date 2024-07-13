using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Features.Auth.Commands.Login;
using TaskManagementSystem.Application.Features.Auth.Commands.Register;

namespace TaskManagementSystem.WebAPI.Controllers;

public class AuthController : BaseController
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
         var result = await _mediator.Send(command);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}