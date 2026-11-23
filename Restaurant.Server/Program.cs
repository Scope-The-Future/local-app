using Microsoft.EntityFrameworkCore;
using Npgsql;
using Restaurant.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")!));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbcheck", (AppDbContext context) => context.Points.Count());

using (var scope = app.Services.CreateScope())
{
    var sp = scope.ServiceProvider;
    var db = sp.GetRequiredService<AppDbContext>();
    var cfg = sp.GetRequiredService<IConfiguration>();

    for (int attempt = 0; ; attempt++)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (NpgsqlException) when (attempt < 5)
        {
            await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)));
        }
    }
}


app.Run();
