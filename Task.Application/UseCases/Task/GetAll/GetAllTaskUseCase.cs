using Task.Application.Interfaces;
using Task.Communication.Responses;

namespace Task.Application.UseCases.Task.GetAll;

public class GetAllTaskUseCase : IGetAllTaskUseCase
{
    private readonly ITaskRepository _repository;

    public GetAllTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public ResponseAllTask Execute()
    {
        var tasks = _repository.GetAll();

        var response = new ResponseAllTask
        {
            Tasks = tasks.Select(t => new ResponseTask
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                Status = t.Status
            }).ToList()
        };

        return response;
    }
}
