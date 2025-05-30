using System.Diagnostics.Eventing.Reader;

namespace Back.Dtos;

public record PutMedicineDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Dose { get; set; } = null!;
    public string RulesOfTaking { get; set; } = null!;
}