namespace Back.Dtos;

public record GetTimeSlotDTO
{
    public string Date { get; set; } = null!;
    public string Address { get; set; } = null!;
    public List<TimeSpan> times { get; set; } = new List<TimeSpan>();
}