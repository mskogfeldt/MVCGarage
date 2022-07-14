using Microsoft.EntityFrameworkCore;
using MVCGarage;
using MVCGarage.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCGarageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCGarageContext") ?? throw new InvalidOperationException("Connection string 'MVCGarageContext' not found.")));

var _configuration = builder.Configuration;
builder.Services.AddSingleton(_configuration.GetSection("Price").Get<PriceSettings>());
builder.Services.Configure<PriceSettings>(_configuration.GetSection("Price").Bind);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=ParkedVehicles}/{action=Index}/{id?}");

app.Run();