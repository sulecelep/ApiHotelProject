using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DbContext ve Identity Tanýmlandý
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddHttpClient(); //Api Consume ederken gerekiyor
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
