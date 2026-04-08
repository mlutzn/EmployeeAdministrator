using Microsoft.AspNetCore.Mvc;
using DTO;
using AppLogic;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IEmployeeConnector _employeeConnector;
    private readonly JwtService _jwtService;

    public AuthController(IEmployeeConnector employeeConnector, JwtService jwtService)
    {
        _employeeConnector = employeeConnector;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        var user = _employeeConnector.ValidateCredentials(request.Email, request.Password);
        if (user == null)
            return Unauthorized("Credenciales inválidas");
     
        var token = _jwtService.GenerateToken(user);
        //LOG
        Console.WriteLine($"Usuario: {user.Email}, Rol: {user.Rol}, Token:{token}");
        return Ok(new LoginResponseDto { Token = token, Expiration = DateTime.UtcNow.AddMinutes(60) });
    }
}