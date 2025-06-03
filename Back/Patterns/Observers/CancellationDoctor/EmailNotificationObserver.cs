using Back.Services;
using Back.Models;

namespace Back.Patterns;

public class EmailNotificationObserver : IReceptionCancellationObserver
{
    private readonly IEmailService emailService;
    public EmailNotificationObserver(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    public async Task NotifyAsync(AppointmentEntity appointmentEntity, string reason)
    {
        await emailService.SendCancel(appointmentEntity, reason);
    }
}