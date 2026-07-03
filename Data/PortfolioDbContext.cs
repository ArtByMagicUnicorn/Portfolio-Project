using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Models;

namespace Portfolio_Project.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
        : base(options)
    {
    }

    public DbSet<PortfolioProject> Projects => Set<PortfolioProject>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PortfolioProject>()
            .HasIndex(project => project.Slug)
            .IsUnique();
    }
}