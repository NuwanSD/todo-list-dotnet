using System;

namespace API.Entities;

public class TodoItem
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsCompleted { get; set; }

    public DateTime? DueDate { get; set; }

}
