using Microsoft.EntityFrameworkCore;
using StarMaxApp.Models;

namespace StarMaxApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Starship>? Starships { get; set; }
}
