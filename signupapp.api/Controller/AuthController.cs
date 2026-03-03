using Microsoft.AspNetCore.Mvc;
using SignupApp.API.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signup")]
    public IActionResult Signup(SignupRequestDto request)
    {
        var result = _authService.Signup(request);

        if (!result)
            return BadRequest("Signup failed");

        return Created("", "User created successfully");
    }
}