using Task.Application.Exceptions;
using Task.Application.Interfaces;
using Task.Communication.Responses;

namespace Task.Application.UseCases.Task.GetById;

public class GetTaskByIdUseCase : IGetTaskByIdUseCase
{
    private readonly ITaskRepository _repository;

    public GetTaskByIdUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public ResponseTask Execute(Guid id)
    {
        var task = _repository.GetById(id);

        if (task == null)
            throw new NotFoundException("Tarefa não encontrada.");

        var response = new ResponseTask
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            Priority = task.Priority,
            DueDate = task.DueDate,
            Status = task.Status
        };

        return response;

    }
}
