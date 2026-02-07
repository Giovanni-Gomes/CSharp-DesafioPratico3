using Task.Communication.Requests;
using Task.Communication.Responses;

namespace Task.Application.Interfaces;

public interface ICreateTaskUseCase
{
    ResponseCreateTask Execute(RequestTask request);
}
