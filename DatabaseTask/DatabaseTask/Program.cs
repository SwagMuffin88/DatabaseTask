using DatabaseTask.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

LoadEnvironmentFile(Path.Combine(builder.Environment.ContentRootPath, "..", ".env"));

var databaseUsername = Environment.GetEnvironmentVariable("MS_SQL_USERNAME")
    ?? throw new InvalidOperationException("MS_SQL_USERNAME is not configured.");
var databasePassword = Environment.GetEnvironmentVariable("MS_SQL_PASSWORD")
    ?? throw new InvalidOperationException("MS_SQL_PASSWORD is not configured.");

var connectionString = new SqlConnectionStringBuilder
{
    DataSource = builder.Configuration["Database:Server"],
    InitialCatalog = builder.Configuration["Database:Name"],
    UserID = databaseUsername,
    Password = databasePassword,
    TrustServerCertificate = true,
    MultipleActiveResultSets = true
}.ConnectionString;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseTaskDbContext>(options => 
    options.UseSqlServer(connectionString));

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

static void LoadEnvironmentFile(string path)
{
    if (!File.Exists(path))
    {
        return;
    }

    foreach (var line in File.ReadLines(path))
    {
        var trimmedLine = line.Trim();
        if (trimmedLine.Length == 0 || trimmedLine.StartsWith('#'))
        {
            continue;
        }

        var separatorIndex = trimmedLine.IndexOf('=');
        if (separatorIndex <= 0)
        {
            continue;
        }

        var name = trimmedLine[..separatorIndex].Trim();
        var value = trimmedLine[(separatorIndex + 1)..].Trim().Trim('"', '\'');

        if (Environment.GetEnvironmentVariable(name) is null)
        {
            Environment.SetEnvironmentVariable(name, value);
        }
    }
}
