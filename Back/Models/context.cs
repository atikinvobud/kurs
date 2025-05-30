using Microsoft.EntityFrameworkCore;

namespace Back.Models;

public class Context : DbContext
{
    public DbSet<AppointmentEntity> Appointments { get; set; } = null!;
    public DbSet<ConclusionEntity> Conclusions { get; set; } = null!;
    public DbSet<DistinctEntity> Distincts { get; set; } = null!;
    public DbSet<DoctorEntity> Doctors { get; set; } = null!;
    public DbSet<DoctorPolyclinicEntity> DoctorsPolyclinic { get; } = null!;
    public DbSet<ExaminationEntity> Examinations { get; set; } = null!;
    public DbSet<MedicalCardEntity> MedicalCards { get; set; } = null!;
    public DbSet<MedicineEntity> Medicines { get; set; } = null!;
    public DbSet<PatientEntity> Patients { get; set; } = null!;
    public DbSet<PolyclinicEntity> Polyclinics { get; set; } = null!;
    public DbSet<ReceptionEntity> Receptions { get; set; } = null!;
    public DbSet<ReceptionMedicineEntity> ReceptionMedicines { get; set; } = null!;
    public DbSet<RegistrationOfficeEntity> RegistrationOffices { get; set; } = null!;
    public DbSet<ScheduleEntity> Schedules { get; set; } = null!;
    public DbSet<SickLeaveEntity> SickLeaves { get; set; } = null!;
    public DbSet<SpecializationEntity> Specializations { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new ConclusionConfiguration());
        modelBuilder.ApplyConfiguration(new DistinctConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorPolyclinicConfiguration());
        modelBuilder.ApplyConfiguration(new ExaminationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalCardConfiguration());
        modelBuilder.ApplyConfiguration(new MedicineConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new PolyclinicConfiguration());
        modelBuilder.ApplyConfiguration(new ReceptionConfiguration());
        modelBuilder.ApplyConfiguration(new ReceptionMedicineConfiguration());
        modelBuilder.ApplyConfiguration(new RegistrationOfficeConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new SickLeaveConfiguration());
        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}