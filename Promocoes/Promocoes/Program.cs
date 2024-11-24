using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Promocoes.Context;
using Promocoes.Repositories.Campaigns;
using Promocoes.Repositories.Coupons;
using Promocoes.Repositories.Promotions;
using Promocoes.Services.Campaigns;
using Promocoes.Services.Coupons;
using Promocoes.Services.Promotions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dbConnection));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PromocoesAPI",
        Version = "v1",
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Registro dos repositórios e serviços
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Promocoes API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
