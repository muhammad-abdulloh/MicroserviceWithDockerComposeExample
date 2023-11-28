using Microsoft.EntityFrameworkCore;
using School.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString = $"Data Source=localhost,8088;Initial Catalog={dbName};User ID=sa;Password={dbPassword};Trusted_Connection=True";

//var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Persist Security Info=True;Trusted_Connection = True";

builder.Services.AddDbContext<SchoolDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
