using Microsoft.EntityFrameworkCore;
using RawsonbpoTestProject.Repository.Context;
using RawsonbpoTestProject.Repository.Repositories.Classes;
using RawsonbpoTestProject.Repository.Repositories.Interfaces;
using RawsonbpoTestProject.Services.Services.Classes;
using RawsonbpoTestProject.Services.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<MyDBContext>();
builder.Services.AddScoped<IRegisterUserInfoService, RegisterUserInfoService>();
builder.Services.AddScoped<IRegisterUserInfoRepository, RegisterUserInfoRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
