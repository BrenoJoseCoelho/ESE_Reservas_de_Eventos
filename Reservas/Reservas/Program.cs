
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReservasApi.Context;
using ReservasApi.Repositories.Participants;
using ReservasApi.Repositories.Reservations;
using ReservasApi.Services.Participants;
using ReservasApi.Services.Reservations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dbConnection));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ReservasAPI",
        Version = "v1",
    });
});

// Registro dos repositórios e serviços
builder.Services.AddHttpClient<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservas API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
