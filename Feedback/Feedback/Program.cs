using Feedback.Context;
using Feedback.Repositories;
using Feedback.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHttpClient();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dbConnection));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FeedbackAPI",
        Version = "v1",
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Registro dos repositórios e serviços
builder.Services.AddScoped<IFeedbackNoteRepository, FeedbackNoteRepository>();
builder.Services.AddScoped<IFeedbackNoteService, FeedbackNoteService>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feedback API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
