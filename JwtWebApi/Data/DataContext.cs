using JwtWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Character> Characters { get; set; } = null!;
}
