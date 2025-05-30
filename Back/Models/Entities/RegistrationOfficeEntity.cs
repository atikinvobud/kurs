namespace Back.Models;

public record RegistrationOfficeEntity
{
    public int Id { get; set; }
    public required string Address { get; set; }
    public required int UserId { get; set; }

    public PolyclinicEntity? polyclinicEntity { get; set; }
    public UserEntity? userEntity { get; set; }
}