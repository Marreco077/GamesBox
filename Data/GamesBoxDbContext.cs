using GamesBox.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesBox.Data;

using GamesBox.Entities;
public class GamesBoxDbContext : DbContext
{
    public GamesBoxDbContext(DbContextOptions<GamesBoxDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Game> Games { get; set; }
}