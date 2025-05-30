namespace Back.Dtos;

public record GetTicketDTO
{
    public string FIO { get; set; } = null!;
    public string Doctor { get; set; } = null!;
    public string SpecializationName { get; set; } = null!;
    public DateOnly Date { get; set; }
    public TimeSpan Time { get; set; }
    public int Cabinet { get; set; }
}