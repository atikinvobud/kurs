namespace Back.Dtos;

public record GetShortSickLeaveDTO
{
    public int Id { get; set; }
    public int Length { get; set; }
    public DateOnly StartDate { get; set; }
}