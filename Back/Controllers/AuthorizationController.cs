
using Back.Dtos;
using Back.DTOs;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly RegistrationService registrationService;
    private readonly IAuthorizationService authorizationService;
    private readonly IJwtService jwtService;
    public AuthorizationController(RegistrationService registrationService, IJwtService jwtService, IAuthorizationService authorizationService)
    {
        this.registrationService = registrationService;
        this.jwtService = jwtService;
        this.authorizationService = authorizationService;
    }
    [HttpPost("patient")]
    public async Task<IActionResult> RegistrPatient([FromBody] PatientRegistrationDto patientRegistrationDto)
    {
        bool success =await registrationService.RegisterUserAsync("patient", patientRegistrationDto);
        if (!success) return Conflict();
        return Ok();
    }

    [HttpPost("doctor")]
    public async Task<IActionResult> RegistrDoctor([FromBody] DoctorRegistrationDTO doctorRegistrationDTO)
    {
        bool success =await registrationService.RegisterUserAsync("doctor", doctorRegistrationDTO);
        if(!success) return Conflict();
        return Ok();
    }

    [HttpPost("registratura")]
    public async Task<IActionResult> RegistrRegistratura([FromBody] RegistrationOfficeDTO registrationOfficeDTO)
    {
        bool success =await registrationService.RegisterUserAsync("registratura", registrationOfficeDTO);
        if(!success) return Conflict(); 
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        var strategy = await authorizationService.GetStrategyAsync(dto);
        if (strategy == null) return NotFound();
        var result = await strategy.AuthorizeAsync(dto);
        
        if (result == null) return Unauthorized();

        var token = jwtService.GenerateToken(result.User);
        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = DateTime.UtcNow.AddHours(12)
        });

        return Ok(new
        {
            result.MainPage,
            result.AllowedPages
        });
    }
}