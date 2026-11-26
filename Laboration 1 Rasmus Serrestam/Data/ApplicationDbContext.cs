using Laboration_1_Rasmus_Serrestam.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboration_1_Rasmus_Serrestam.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Item> Items => Set<Item>();

    public DbSet<ItemCondition> ItemConditions => Set<ItemCondition>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>()
            .HasOne(item => item.Condition)
            .WithMany(condition => condition.Items)
            .HasForeignKey(item => item.ConditionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemCondition>()
            .HasIndex(condition => condition.Name)
            .IsUnique();
    }
}