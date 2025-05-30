public interface IAppointmentCommand<TResult>
{
    Task<TResult> Execute(int scheduleId);
}
