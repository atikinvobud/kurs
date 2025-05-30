using System.Data;

namespace Back.Dtos;

public record GetDistinctDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; 
}