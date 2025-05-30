using MongoDB.Bson.Serialization.Conventions;

namespace Back.Models;

public class TicketBuilder : ITicketBuilder
{
    private Ticket ticket = new();
    public void SetPatient(string FIO)
    {
        ticket.FIO = FIO;
    }
    public void SetDoctor(string DoctorFIO, string specialization)
    {
        ticket.Doctor = DoctorFIO;
        ticket.SpecializationName = specialization;
    }
    public void SetTime(DateOnly date, TimeSpan time)
    {
        ticket.Date = date;
        ticket.Time = time;
    }
    public void SetCabinet(int cabinet)
    {
        ticket.Cabinet = cabinet;
    }
    public Ticket Build()
    {
        Ticket result = ticket;
        ticket = new();
        return result;
    }
}