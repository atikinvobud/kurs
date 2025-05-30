using back.Services;
using Back.Models;

namespace Back.Patterns;

public class EmailNotificationObserver : IReceptionCancellationObserver
{
    private readonly EmailService emailService;
    public EmailNotificationObserver(EmailService emailService)
    {
        this.emailService = emailService;
    }

    public async Task NotifyAsync(AppointmentEntity appointmentEntity, string reason)
    {
        await emailService.SendCancel(appointmentEntity, reason);
    }
}