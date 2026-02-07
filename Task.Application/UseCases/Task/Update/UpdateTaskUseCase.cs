using Task.Application.Exceptions;
using Task.Application.Interfaces;
using Task.Communication.Enums;
using Task.Communication.Requests;
using Task.Communication.Responses;
using TaskStatus = Task.Communication.Enums.TaskStatus;

namespace Task.Application.UseCases.Task.Update;

public class UpdateTaskUseCase : IUpdateTaskUseCase
{
    private readonly ITaskRepository _repository;

    public UpdateTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public ResponseUpdateTask Execute(Guid id, RequestTask request)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(request.Name) || request.Name.Length > 100)
            errors.Add("O nome é obrigatório e deve ter no máximo 100 caracteres.");

        if (request.Description != null && request.Description.Length > 500)
            errors.Add("A descrição deve ter no máximo 500 caracteres.");

        if (request.DueDate < DateTime.UtcNow)
            errors.Add("A data de vencimento deve ser no futuro.");

        if (!Enum.IsDefined(typeof(TaskStatus), request.Status))
        {
            errors.Add("Status inválido. Os valores permitidos são: Pending = 0, InProgress = 1, Completed = 2.");
        }

        if (!Enum.IsDefined(typeof(TaskPriority), request.Priority))
        {
            errors.Add("Prioridade inválida. Os valores permitidos são: Low = 0, Medium = 1, High = 2.");
        }

        if (errors.Any())
            throw new ValidationException(errors);

        var updatedTaskId = _repository.Update(id, request);

        if (updatedTaskId == Guid.Empty)
            throw new NotFoundException($"Tarefa com ID {id} não encontrada.");

        return new ResponseUpdateTask
        {
            Id = updatedTaskId
        };
    }
}
