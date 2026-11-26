using Laboration_1_Rasmus_Serrestam.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboration_1_Rasmus_Serrestam.Data;

public class DatabaseInitializer
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public DatabaseInitializer(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task InitializeAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        // Create database and tables if they do not exist
        await context.Database.EnsureCreatedAsync();
        await context.Database.EnsureCreatedAsync();

        //System.Diagnostics.Debug.WriteLine($"Database path: {FileSystem.AppDataDirectory}");

        // Seed data only if the database is empty
        if (await context.Items.AnyAsync())
            return;

        var conditions = new List<ItemCondition>
        {
            new() { Id = 1, Name = "New" },
            new() { Id = 2, Name = "Like New" },
            new() { Id = 3, Name = "Used" },
            new() { Id = 4, Name = "Poor" }
        };

        context.ItemConditions.AddRange(conditions);

        var items = new List<Item>
        {
            new()
            {
                Id = 1,
                Title = "MacBook Air M2",
                Price = 8500,
                ConditionId = 2,
                Description = "MacBook Air M2 in excellent condition.",
                SellerEmail = "seller1@example.com"
            },
            new()
            {
                Id = 2,
                Title = "Sony WH-1000XM5",
                Price = 2000,
                ConditionId = 3,
                Description = "Wireless noise cancelling headphones.",
                SellerEmail = "seller2@example.com"
            },
            new()
            {
                Id = 3,
                Title = "Nike Air Force 1",
                Price = 600,
                ConditionId = 2,
                Description = "White sneakers in very good condition.",
                SellerEmail = "seller3@example.com"
            },
            new()
            {
                Id = 4,
                Title = "Nintendo Switch OLED",
                Price = 2200,
                ConditionId = 3,
                Description = "Nintendo Switch OLED with accessories.",
                SellerEmail = "seller4@example.com"
            },
            new()
            {
                Id = 5,
                Title = "iPhone 15",
                Price = 6500,
                ConditionId = 2,
                Description = "iPhone 15 with original box.",
                SellerEmail = "seller5@example.com"
            },
            new()
            {
                Id = 6,
                Title = "Samsung 4K Monitor",
                Price = 1800,
                ConditionId = 1,
                Description = "New 4K monitor, never used.",
                SellerEmail = "seller6@example.com"
            },
            new()
            {
                Id = 7,
                Title = "Logitech Gaming Mouse",
                Price = 450,
                ConditionId = 3,
                Description = "Gaming mouse in good working condition.",
                SellerEmail = "seller7@example.com"
            }
        };

        context.Items.AddRange(items);

        await context.SaveChangesAsync();
    }
}
