using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace Back.Dtos;

public record PutConclusionDTO
{
    public int Id { get; set; }
    public string Diagnos { get; set; } = null!;
    public string Description { get; set; } = null!;
}