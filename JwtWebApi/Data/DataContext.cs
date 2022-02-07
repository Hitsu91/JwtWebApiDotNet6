using JwtWebApi.Models;
using JwtWebApi.Services.AuthService;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var (hash, salt) = AuthService.HashPassword("admin");
        
        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Username = "Admin", PasswordHash = hash, PasswordSalt = salt, Role = Role.Admin }
        );
        
        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = Guid.NewGuid(), Name = "Fireball", Damage = 300 },
            new Skill { Id = Guid.NewGuid(), Name = "Frenzy", Damage = 20 }
        );
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Weapon> Weapons { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
}
