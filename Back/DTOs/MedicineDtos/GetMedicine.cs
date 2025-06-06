namespace Back.Dtos;

public record GetMedicineDTO
{
    
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public TimeSpan Lehgth { get; set; }
    public string Name { get; set; } = null!;
    public string Dose { get; set; } = null!;
    public string RulesOfTaking { get; set; } = null!;

}