using Task.Communication.Model;
using Task.Communication.Enums;
using TaskStatus = Task.Communication.Enums.TaskStatus;
using Task.Application.Interfaces;
using Task.Communication.Requests;

namespace Infrastructure;

public class InMemoryTaskRepository : ITaskRepository
{
    private static readonly List<TaskModel> _tasks = new()
    {
        new TaskModel
        {
            Id = Guid.NewGuid(),
            Name = "Task 1",
            Description = "Description for Task 1",
            Priority = TaskPriority.High,
            DueDate = DateTime.UtcNow.AddDays(7),
            Status = TaskStatus.Pending
        },
        new TaskModel
        {
            Id = Guid.NewGuid(),
            Name = "Task 2",
            Description = "Description for Task 2",
            Priority = TaskPriority.Medium,
            DueDate = DateTime.UtcNow.AddDays(14),
            Status = TaskStatus.InProgress
        },
        new TaskModel
        {
            Id = Guid.NewGuid(),
            Name = "Task 3",
            Description = "Description for Task 3",
            Priority = TaskPriority.Low,
            DueDate = DateTime.UtcNow.AddDays(30),
            Status = TaskStatus.Completed
        }
    };

    public List<TaskModel> GetAll()
    {
        return _tasks;
    }

    public TaskModel? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public Guid Add(RequestTask task)
    {
        var newTask = new TaskModel
        {
            Id = Guid.NewGuid(),
            Name = task.Name,
            Description = task.Description,
            Priority = task.Priority,
            DueDate = task.DueDate,
            Status = task.Status
        };
        _tasks.Add(newTask);

        return newTask.Id;
    }

    public bool Remove(Guid id) 
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
            return true;
        }
        return false;
    }

    public Guid Update(Guid id, RequestTask request)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Name = request.Name;
                existingTask.Description = request.Description;
                existingTask.Priority = request.Priority;
                existingTask.DueDate = request.DueDate;
                existingTask.Status = request.Status;
                return existingTask.Id;
            }
            return Guid.Empty;

    }
}
