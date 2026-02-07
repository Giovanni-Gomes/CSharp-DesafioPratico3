using System.ComponentModel.DataAnnotations;
using Task.Communication.Enums;

namespace Task.Communication.Requests;

public class RequestTask
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(500)]
    public string? Description { get; set; }
    [Required]
    public TaskPriority Priority { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public Enums.TaskStatus Status { get; set; }
}
