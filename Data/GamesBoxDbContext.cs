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
            // ID auto configured -- EF does that
            entity.Property(g => g.Name).IsRequired().HasMaxLength(250);
            entity.Property(g => g.Summary).IsRequired().HasMaxLength(2000);
            entity.Property(g => g.Date).IsRequired();
            entity.Property(g => g.Score).IsRequired().HasPrecision(3, 1);
            entity.Property(g => g.Director).IsRequired().HasMaxLength(250);
            entity.Property(g => g.Writers).HasMaxLength(250);
            entity.Property(g => g.Company).HasMaxLength(200);
        });

        builder.Entity<User>(entity =>
        {   
            // ID auto configured
            entity.Property(u => u.Name).IsRequired().HasMaxLength(250);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(320);
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(100);
            entity.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        builder.Entity<GameReview>(entity =>
        {   
            // ID auto configured
            entity.Property(r => r.Review).HasMaxLength(5000);
            entity.Property(r => r.Score).IsRequired().HasPrecision(3, 1);
            entity.Property(r => r.Like).IsRequired();
            entity.Property(r => r.Finished).IsRequired();
            entity.Property(r => r.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            entity.HasOne(r => r.Game).WithMany().HasForeignKey(r => r.GameId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);

        });
    }
}