using System.Reflection.Metadata;

namespace Back.Dtos;

public record GettFullInfoDTO
{
    public int PolyclinicId { get; set; }
    public string Address { get; set; } = null!;
    public string Passport { get; set; } = null!;
    public string Snils { get; set; } = null!;
    public string Polis { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public int Length { get; set; }
    public string Diagnos { get; set; } = null!;
    public string DoctorFIO { get; set; } = null!;

}