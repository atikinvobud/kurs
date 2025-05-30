using System.Text;
using System.Text.Json;
using Back.Dtos;
using Back.Models;
using Back.Patterns;
using Back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

//DI контейнеры
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IJwtService,JwtService>();
builder.Services.AddScoped<IDistinctService,DistinctService>();
builder.Services.AddScoped<IScheduleService,ScheduleService>();
builder.Services.AddScoped<IPolyclinicService,PolyclinicService>();
builder.Services.AddScoped<IMedicineService,MedicineService>();
builder.Services.AddScoped<ISpecializationService,SpecializationService>();
builder.Services.AddScoped<IConclusionService,ConclusionService>();
builder.Services.AddScoped<ISickLeaveService,SickLeaveService>();
builder.Services.AddScoped<PatientRegistrationStrategy>();
builder.Services.AddScoped<DoctorRegistrationStrategy>();
builder.Services.AddScoped<RegistrationOfficeRegistrationStrategy>();
builder.Services.AddScoped<PatientAuthStrategy>();
builder.Services.AddScoped<DoctorAuthStrategy>();
builder.Services.AddScoped<OfficeAuthStrategy>();
builder.Services.AddScoped<IAuthorizationService,AuthorizationService>();
builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<IPasswordResetService,PasswordResetService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICollectionInfoService,CollectionInfoService>();
builder.Services.AddScoped<IMedicalCardService,MedicalCardService>();
builder.Services.AddScoped<ITicketService,TicketService>();
builder.Services.AddScoped<ITicketBuilder, TicketBuilder>();
builder.Services.AddScoped<IPdfService,PdfService>();
builder.Services.AddScoped<IAppointmentService,AppointmentService>();
builder.Services.AddScoped<CommandAppointmentInvoker>();
builder.Services.AddScoped<IReceptionService,ReceptionService>();
builder.Services.AddScoped<IRegistraturaService,RegistraturaService>();
builder.Services.AddScoped<RegistrationService>(provider =>
{
    var strategies = new Dictionary<string, IRoleRegistrationStrategy>
    {
        ["patient"] = provider.GetRequiredService<PatientRegistrationStrategy>(),
        ["doctor"] = provider.GetRequiredService<DoctorRegistrationStrategy>(),
        ["registratura"] = provider.GetRequiredService<RegistrationOfficeRegistrationStrategy>()
    };

    return new RegistrationService(strategies);
});
builder.Services.AddScoped<IReceptionCancellationObserver, EmailNotificationObserver>();

builder.Services.AddScoped<CancelationNotifier>(sp =>
{
    var observers = sp.GetServices<IReceptionCancellationObserver>();
    var notifier = new CancelationNotifier();
    foreach (var observer in observers)
    {
        notifier.Attach(observer);
    }
    return notifier;
});

//настройка контроллеров
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
       options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // camelcase     

        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        // Опционально: Сделать вывод более удобным (без лишних пробелов и строк)
        options.JsonSerializerOptions.WriteIndented = false;
    });

//подключение сваггера часть 1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Policlinic",
        Version = "v1"
    });
});

//подключение к бд postgres
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

//подключение к mongodb
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("MongoDb");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<MongoDbContext>();




//настройка JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetValue<string>("JwtSettings:SecretKey") ?? "default_secret_key"
            )),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["jwt"];
                return Task.CompletedTask;
            }
        };
    });


var app = builder.Build();

//подключение сваггера часть 2
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

});

app.UseHttpsRedirection();

app.UseRouting();

//настройка авторизации
app.UseAuthentication();
app.UseAuthorization();

//настройка контроллеров
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
