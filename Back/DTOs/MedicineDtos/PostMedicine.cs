namespace Back.Dtos;

public record PostMedicineDTO
{
    public string Name { get; set; } = null!;
    public string Dose { get; set; } = null!;
    public string RulesOfTaking { get; set; } = null!;
}