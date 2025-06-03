using System.Threading.Tasks;
using Back.Services;
using Back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers;

[ApiController]
[Route("mail")]

public class ResetPasswordController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IPasswordResetService passwordResetService;
    private readonly IEmailService emailSerivce;

    public ResetPasswordController(IUserService userService, IPasswordResetService passwordResetService, IEmailService emailService)
    {
        this.userService = userService;
        this.passwordResetService = passwordResetService;
        this.emailSerivce = emailService;
    }

    [HttpPost("create-reset-code/{login}")]
    public async Task<IActionResult> CreateResetCode([FromRoute] string login)
    {
        UserEntity? user = await userService.FindUserByLogin(login);
        if (user == null) return NotFound();

        string code = await passwordResetService.CreateResetCode(user.Id);

        await emailSerivce.SendPasswordResetEmailAsync(login, code);
        return Ok();
    }

    [HttpPost("verify-reset-code/{login}/{code}")]
    public async Task<IActionResult> VerifyResetCode([FromRoute] string login, [FromRoute] string code)
    {
        UserEntity? user = await userService.FindUserByLogin(login);
        if (user == null) return NotFound();

        bool isSuccesseful = await passwordResetService.VerifyResetCode(user.Id, code);
        if(isSuccesseful) return Ok();
        return NotFound();
    }

    [HttpPost("update-password/{login}/{password}")]
    public async Task<IActionResult> UpdatePassword([FromRoute] string login, [FromRoute] string password)
    {
        UserEntity? user = await userService.FindUserByLogin(login);
        if (user == null) return NotFound();

        user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        await userService.Update(password,user.Id);
        return Ok();
    }
}