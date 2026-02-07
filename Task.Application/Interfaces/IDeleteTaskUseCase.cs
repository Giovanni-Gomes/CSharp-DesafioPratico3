namespace Task.Application.Interfaces;

public interface IDeleteTaskUseCase
{
    void Execute(Guid id);
}
