namespace Back.Models;

public interface ITicketBuilder
{
    void SetPatient(string FIO);
    void SetDoctor(string DoctorFIO, string specialization);
    void SetTime(DateOnly date, TimeSpan time);
    void SetCabinet(int cabinet);
    Ticket Build();
}