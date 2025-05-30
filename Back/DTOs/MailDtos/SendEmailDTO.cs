namespace Back.Dtos;

public class SendEmailDTO
{
    public string EmailAddress {get; set;} =null!;
    public string Title { get; set; } = null!;
    public string Context {get; set;} = null!;
}