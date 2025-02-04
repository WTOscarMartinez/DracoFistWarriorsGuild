using System.Diagnostics;
using DracoFistWarriorsGuild.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Bring in database context with dependency injection.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GuildConnection")));

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    
    // Apply any pending migrations and create the database if it doesn't exist
    context.Database.Migrate();

    // Seed data if necessary
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Automatically open browser when app starts
var url = "http://localhost:5160";
await Task.Run(() => Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }));

app.Run();
