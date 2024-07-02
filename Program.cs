using Dapper;
using Npgsql;
using VirtualApp.Models;
using VirtualApp.Repositories;
using VirtualApp.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUserRepository, UserDapperRepository>();

var connection = new NpgsqlConnection("Server=prodpostgre.postgres.database.azure.com;Database=postgres;Port=5432;User Id=kirisa;Password=Alekto134;Ssl Mode=Require;");
try
{
    var sql = File.ReadAllText("Assets/init.sql");
    connection.Execute(sql);
}
catch (Exception) {}


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
