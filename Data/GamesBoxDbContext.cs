using Microsoft.EntityFrameworkCore;
using GamesBox.Entities;

namespace GamesBox.Data;

public class GamesBoxDbContext : DbContext
{
    public GamesBoxDbContext(DbContextOptions<GamesBoxDbContext> options) : base(options) { } 
    
    public DbSet<Game> Games { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<GameReview> GameReviews { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Game>(entity =>
        {   
            entity.Property(e => e.Name).IsRequired().HasMaxLength(250);
            entity.Property(e => e.Summary).IsRequired().HasMaxLength(2000);
            entity.Property(e => e.Director).IsRequired().HasMaxLength(250);
            entity.Property(e => e.Writers).HasMaxLength(250);
            entity.Property(e => e.Company).HasMaxLength(200);
        });

        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(250);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(320);
        });

        builder.Entity<GameReview>(entity =>
        {
            entity.Property(e => e.Score).IsRequired();
            entity.Property(e => e.Finished).IsRequired();
            entity.Property(e => e.Game).HasOne()
            entity.Property(e => e.GameId).IsRequired();
            entity.Property(e => e.Like).IsRequired();
            entity.Property(e => e.Review).IsRequired().HasMaxLength(5000);
            entity.Property(e => e.User).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
        });
    }
}