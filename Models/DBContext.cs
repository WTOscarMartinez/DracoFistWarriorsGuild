using Microsoft.EntityFrameworkCore;

namespace DracoFistWarriorsGuild.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Member>? Members {get; set;}
    public DbSet<Quest>? Quests {get; set;}
}