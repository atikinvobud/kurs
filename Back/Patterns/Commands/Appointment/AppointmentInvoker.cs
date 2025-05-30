namespace Back.Patterns;

public class CommandAppointmentInvoker
{
    public async Task<TResult> Invoke<TResult>(IAppointmentCommand<TResult> command, int id)
    {
        return await command.Execute(id);
    }
}
