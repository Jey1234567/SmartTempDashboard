using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartTempDashboard.Models;
using SmartTempDashboard.SignalRHubs;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//For Entity Framework MSQL Connection
builder.Services.AddDbContext<TemperatureDBContext>(options =>
{
    //Change to your SQL Server Name
    options.UseSqlServer("Server=ServerName\\SQLEXPRESS;Database=TemperatureDB;Trusted_Connection=True;TrustServerCertificate=True;");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddHttpClient();
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(7111); // <- Add this to support HTTP
});
builder.Services.AddSignalR();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//SignalR
app.MapHub<ChartHub>("/charthub");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Web API V1");
    c.RoutePrefix = "swagger"; // Bisa diakses di /swagger
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
