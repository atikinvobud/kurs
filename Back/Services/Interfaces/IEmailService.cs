using Back.Dtos;
using Back.Models;
namespace Back.Services;

public interface IEmailService
{
    Task SendCancel(AppointmentEntity appointmentEntity, string reason);
    Task SendEmailAsync(SendEmailDTO sendEmailDTO);
    Task SendPasswordResetEmailAsync(string emailAddress, string code);
}