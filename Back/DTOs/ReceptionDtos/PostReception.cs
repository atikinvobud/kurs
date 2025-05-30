using System.Data;

namespace Back.Dtos;

public record PostReceptionDTO
{
    public TimeSpan Length { get; set; }
    public int MedicalCardId { get; set; }
    public List<int> MedicineIds { get; set; } = new List<int>();
    public List<int> ExaminationIds { get; set; } = new List<int>();
}