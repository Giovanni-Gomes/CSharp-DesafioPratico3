using Task.Communication.Responses;

namespace Task.Application.Interfaces;

public interface IGetTaskByIdUseCase
{
    ResponseTask Execute(Guid id);
}
