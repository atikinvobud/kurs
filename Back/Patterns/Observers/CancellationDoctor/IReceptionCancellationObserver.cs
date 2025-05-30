using Back.Models;

namespace Back.Patterns;

public interface IReceptionCancellationObserver
{
    Task NotifyAsync(AppointmentEntity appointmentEntity, string reason);
}