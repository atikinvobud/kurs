namespace Back.DTOs;

public record PutPolyclinicDTO
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int DistinctId { get; set; }
}