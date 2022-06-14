using Dinner.Application.Services.Authentication;
using Dinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;

    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Resister(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
           request.Email,
           request.Password);

        var response = new AuthenticationResponse(
        authResult.User.Id,
        authResult.User.FirstName,
        authResult.User.LastName,
        authResult.User.Email,
        authResult.Token);

        return Ok(response);
    }
}
