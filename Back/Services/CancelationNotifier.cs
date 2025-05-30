using Back.Models;
using Back.Patterns;

namespace Back.Services;

public class CancelationNotifier
{

    private readonly List<IReceptionCancellationObserver> observers = new();

    public void Attach(IReceptionCancellationObserver observer)
    {
        observers.Add(observer);
    }
    public async Task SendAsync(AppointmentEntity appointmentEntity, string reason)
    {
        foreach (var observer in observers)
        {
            await observer.NotifyAsync(appointmentEntity, reason);
        }
    }
}