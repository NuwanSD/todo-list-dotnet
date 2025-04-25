using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateTodoDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public required bool IsCompleted { get; set; }

    [Required]
    public DateTime? DueDate { get; set; }
}
