namespace Back.Dtos;

public record ExtendSickLeaveDTO
{
    public int Id { get; set; }
    public DateOnly newDateOfEnd { get; set; }
}