using Task.Communication.Model;
using Task.Communication.Requests;

namespace Task.Application.Interfaces;

public interface ITaskRepository
{
    List<TaskModel> GetAll();
    TaskModel? GetById(Guid id);
    Guid Add(RequestTask task);
    Guid Update(Guid id, RequestTask request);
    bool Remove(Guid id);

}
