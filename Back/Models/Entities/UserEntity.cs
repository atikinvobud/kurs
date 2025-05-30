namespace Back.Models;

public record UserEntity
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required DateOnly DateOfBirth{ get; set; }

    public RegistrationOfficeEntity? registrationOfficeEntity { get; set; }
    public DoctorEntity? doctorEntity { get; set; }
    public PatientEntity? patientEntity { get; set; }
}