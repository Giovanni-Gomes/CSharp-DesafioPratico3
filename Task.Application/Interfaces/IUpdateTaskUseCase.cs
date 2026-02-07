using Task.Communication.Requests;
using Task.Communication.Responses;

namespace Task.Application.Interfaces;

public interface IUpdateTaskUseCase
{
    ResponseUpdateTask Execute(Guid id, RequestTask request);
}
