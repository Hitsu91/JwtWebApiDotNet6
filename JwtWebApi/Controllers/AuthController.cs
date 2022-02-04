using JwtWebApi.DTOs.User;
using JwtWebApi.Models;
using JwtWebApi.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JwtWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("register")]
    public ActionResult<UserRegistrationResponse> Register(UserRegistrationRequest request)
    {
        try
        {
            return Ok(_authService.Register(request));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 

    [HttpPost("login")]
    public ActionResult<UserLoginResponse> Login(UserLoginRequest request)
    {
        try
        {
            return Ok(_authService.Login(request));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
