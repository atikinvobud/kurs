using MimeKit;
using MailKit.Net.Smtp;
using Back.Dtos;
using Back.Models;

namespace Back.Services;
public class EmailService : IEmailService
{
    private string ourEmailAddress = "atikin123321123@yandex.ru";
    private string ourEmailPassword = "oizkgqkepzahfynu";
    public async Task SendEmailAsync(SendEmailDTO sendEmailDTO)
    {
        using MimeMessage emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Your Polyclinic", ourEmailAddress));
        emailMessage.To.Add(new MailboxAddress("", sendEmailDTO.EmailAddress));
        emailMessage.Subject = sendEmailDTO.Title;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = sendEmailDTO.Context
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.yandex.ru", 465, true);
            await client.AuthenticateAsync(ourEmailAddress, ourEmailPassword);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }

    public async Task SendPasswordResetEmailAsync(string emailAddress, string code)
    {
        string title = "Восстановление пароля Polyclinic";

        string context = $@"
            <html>
            <head>
                <meta charset='UTF-8'>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f9f9f9;
                        padding: 20px;
                    }}
                    .container {{
                        background-color: #ffffff;
                        border: 1px solid #dddddd;
                        border-radius: 5px;
                        padding: 30px;
                        max-width: 600px;
                        margin: auto;
                        text-align: center;
                    }}
                    .code {{
                        display: inline-block;
                        font-size: 24px;
                        font-weight: bold;
                        color: #d9534f;
                        padding: 10px 20px;
                        background-color: #f7f7f7;
                        border-radius: 5px;
                        margin: 20px 0;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h2>Восстановление пароля</h2>
                    <p>Вы запросили восстановление пароля. Используйте следующий код для восстановления доступа:</p>
                    <div class='code'>{code}</div>
                    <p>Если вы не инициировали восстановление пароля, проигнорируйте это письмо.</p>
                    <p>С уважением,<br/>Polyclinic</p>
                </div>
            </body>
            </html>";

        var sendEmailDTO = new SendEmailDTO
        {
            EmailAddress = emailAddress,
            Title = title,
            Context = context
        };

        await SendEmailAsync(sendEmailDTO);
    }

    public async Task SendCancel(AppointmentEntity appointmentEntity, string reason)
    {
        string title = "Отмена записи на прием";

        string html = $@"
        <html>
        <head>
            <meta charset='UTF-8'>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f9f9f9;
                    padding: 20px;
                }}
                .container {{
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    border-radius: 5px;
                    padding: 30px;
                    max-width: 600px;
                    margin: auto;
                    text-align: center;
                }}
                .important {{
                    display: inline-block;
                    font-size: 20px;
                    font-weight: bold;
                    color: #d9534f;
                    padding: 10px 20px;
                    background-color: #f7f7f7;
                    border-radius: 5px;
                    margin: 20px 0;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h2>Отмена записи к врачу</h2>
                <p>Уведомляем вас, что ваш приём был отменён.</p>
                <div class='important'>
                    Врач: <b>{appointmentEntity.scheduleEntity!.doctorEntity!.FIO}</b><br/>
                    Дата приёма: <b>{appointmentEntity.scheduleEntity.Date}</b>
                </div>
                <p>Причина: <i>{reason}</i></p>
                <p>Пожалуйста, свяжитесь с поликлиникой для выбора нового времени или врача.</p>
                <p>С уважением,<br/>Polyclinic</p>
            </div>
        </body>
        </html>";
        var sendEmailDTO = new SendEmailDTO()
        {
            EmailAddress = appointmentEntity.medicalCardEntity!.patientEntity!.userEntity!.Login,
            Title = title,
            Context = html
        };
        await SendEmailAsync(sendEmailDTO);
    }
}