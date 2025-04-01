using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Core.Entities;
using BlogPlatform.Application.Interfaces;
using BlogPlatformAPI.Services;
using BlogPlatformAPI.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace BlogPlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly JwtService _jwtService;

    public AuthController(IUserService userService, JwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        var result = await _userService.CreateUserAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return BadRequest(new { success = false, errors = result.Errors.Select(e => e.Description) });
        }

        var token = _jwtService.GenerateJwtToken(user);

        return Ok(new
        {
            success = true,
            token,
            user = new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.FirstName,
                user.LastName
            }
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        var user = await _userService.GetUserByEmailAsync(model.Email);
        if (user == null)
        {
            return BadRequest(new { success = false, message = "Invalid email or password" });
        }

        var result = await _userService.CheckPasswordAsync(user, model.Password);
        if (!result)
        {
            return BadRequest(new { success = false, message = "Invalid email or password" });
        }

        var token = _jwtService.GenerateJwtToken(user);

        return Ok(new
        {
            success = true,
            token,
            user = new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.FirstName,
                user.LastName
            }
        });
    }
}

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
} 