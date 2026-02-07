using Task.Communication.Enums;

namespace Task.Communication.Responses;

public class ResponseTask
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public Enums.TaskStatus Status { get; set; }
}
