using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Back.Models;

public record DistinctEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public List<PolyclinicEntity> polyclinicEntities { get; set; } = new List<PolyclinicEntity>();
}