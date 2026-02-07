using Task.Communication.Responses;

namespace Task.Application.Interfaces;

public interface IGetAllTaskUseCase
{
    ResponseAllTask Execute();
}
