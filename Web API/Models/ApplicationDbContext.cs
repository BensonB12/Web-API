using Microsoft.EntityFrameworkCore;

namespace Web_API.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BoardGames_Domains>()
            .HasKey(i => new {i.BoardgameId, i.DomainId});

        modelBuilder.Entity<BoardGames_Domains>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGames_Domains)
            .HasForeignKey(z => z.BoardgameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGames_Domains>()
           .HasOne(x => x.Domain)
           .WithMany(y => y.BoardGames_Domains)
           .HasForeignKey(z => z.DomainId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasKey(i => new { i.BoardgameId, i.MechanicId });

        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGames_Mechanics)
            .HasForeignKey(z => z.BoardgameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGames_Mechanics)
            .HasForeignKey(z => z.MechanicId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

    }
    public DbSet<BoardGame> BoardGames => Set<BoardGame>();
    public DbSet<Domain> Domains => Set<Domain>();
    public DbSet<Mechanic> Mechanics => Set<Mechanic>();
    public DbSet<BoardGames_Domains> BoardGames_Domains
        => Set<BoardGames_Domains>();
    public DbSet<BoardGames_Mechanics> BoardGames_Mechanics 
        => Set<BoardGames_Mechanics>();
}
