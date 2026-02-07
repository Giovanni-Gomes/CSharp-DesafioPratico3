using Task.Application.Exceptions;
using Task.Application.Interfaces;

namespace Task.Application.UseCases.Task.Delete;

public class DeleteTaskUseCase : IDeleteTaskUseCase
{
    private readonly ITaskRepository _repository;
    
    public DeleteTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public void Execute(Guid id)
    {
        var isDeleted = _repository.Remove(id);
    
        if (!isDeleted)
            throw new NotFoundException($"Tarefa com ID {id} não encontrada.");
    }
}
