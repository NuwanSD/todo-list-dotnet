using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
            ?? throw new InvalidOperationException("Failed to retive store context");

        await SeedData(context);

    }

    private static async Task SeedData(StoreContext context)
    {
        await context.Database.MigrateAsync();

        if (context.TodoItems.Any()) return;

        var todoItems = new List<TodoItem>
        {
            new() {
                Id = 1,
                Title = "Buy groceries",
                Description = "Milk, Eggs, Bread",
                IsCompleted = false,
                DueDate = DateTime.UtcNow.AddDays(1)
            },
            new() {
                Id = 2,
                Title = "Finish project report",
                Description = "Due by Monday",
                IsCompleted = false,
                DueDate = DateTime.UtcNow.AddDays(2)
            },
            new() {
                Id = 3,
                Title = "Read a book",
                Description = "Start new sci-fi novel",
                IsCompleted = false,
                DueDate = DateTime.UtcNow.AddDays(2)
            },
            new() {
                Id = 4,
                Title = "Call the bank",
                Description = "Ask about credit card fees",
                IsCompleted = false,
                DueDate = DateTime.UtcNow.AddDays(6)
            },
            new() {
                Id = 5,
                Title = "Practice guitar",
                Description = "30 minutes of scales and chords",
                IsCompleted = false,
                DueDate = DateTime.UtcNow.AddDays(6)
            },
        };

        context.TodoItems.AddRange(todoItems);

        await context.SaveChangesAsync();
    }
}
