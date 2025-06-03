using System.Security.Claims;
using Back.Dtos;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetUser()
    {
        int UserId = int.Parse(User.FindFirstValue("userId")!);
        GetUserDTO dto = await userService.GetPersonalInfo(UserId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}