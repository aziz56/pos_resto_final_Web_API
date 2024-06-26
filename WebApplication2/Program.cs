using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using posServices.Domain.Models;
using WebApplication2.Helpers;
using pos.BLL.Interface;
using posServices.Data;
using posServices.Data.Interfaces;
using pos.BLL;
using Microsoft.AspNetCore.Builder;
using posServices.BLL;
using posServices.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IMasterMenuBLL, MasterMenuBLL>();
builder.Services.AddScoped<ITransaksiBLL, TransaksiBLL>();
builder.Services.AddScoped<ITransaksiPenjualanBLL, TransaksiPenjualanBLL>();
builder.Services.AddScoped<ITransaksiPenjualan, TransaksiPenjualanData>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IRoleBLL, RoleBLL>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("pos_restoConnectionString"));
});
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
//app.UseSession();

app.MapControllers();

app.Run();
