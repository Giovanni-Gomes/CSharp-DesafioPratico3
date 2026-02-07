namespace Task.Communication.Responses;

public class ResponseCreateTask
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
