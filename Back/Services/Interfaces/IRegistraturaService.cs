using Back.DTOs;

namespace Back.Services;
public interface IRegistraturaService
{
    Task DeleteDoctorSchedule(DeleteDoctorsAppointmentDTO deleteDoctorsAppointmentDTO);
}