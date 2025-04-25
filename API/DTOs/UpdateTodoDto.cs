using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdateTodoDto
{
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required bool IsCompleted { get; set; }

    [Required]
    public DateTime? DueDate { get; set; }

}
