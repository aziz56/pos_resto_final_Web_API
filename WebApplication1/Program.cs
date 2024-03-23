using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using pos.BLL;
using pos.BLL.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("OwnerPolicy", policy => policy.RequireRole("Owner")); // Hanya pemilik yang bisa mengakses
//    options.AddPolicy("KasirPolicy", policy => policy.RequireRole("Kasir")); // Hanya kasir yang bisa mengakses
//});


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IMasterMenuBLL, MasterMenuBLL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IRoleBLL, RoleBLL>();
builder.Services.AddScoped<ITransaksiBLL, TransaksiBLL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
