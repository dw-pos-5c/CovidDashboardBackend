using CovidDashboard.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using CovidDashboard.DTOs;
using CovidDashboard.Settings;

using Microsoft.Extensions.Options;

namespace CovidDashboard.Controllers;
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService authService;
    private readonly AppSettings appSettings;

    public AuthController(AuthService authService, IOptions<AppSettings> appSettings)
    {
        this.authService = authService;
        this.appSettings = appSettings.Value;
    }

    [HttpGet("{password}")]
    public IActionResult Login(string password)
    {
        var result = new AuthDTO
        {
            Success = false,
            Token = "",
        };
        if (authService.CheckSecret(password))
        {
            var handler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken? token = handler.CreateToken(descriptor);
            result.Token = handler.WriteToken(token);
            result.Success = true;
        }

        return Ok(result);
    }
}
