using Microsoft.AspNetCore.Mvc;
using Task.Application.Interfaces;
using Task.Communication.Requests;
using Task.Communication.Responses;

namespace Task.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ICreateTaskUseCase _createTaskUseCase;
    private readonly IGetAllTaskUseCase _getAllTaskUseCase;
    private readonly IGetTaskByIdUseCase _getTaskByIdUseCase;
    private readonly IUpdateTaskUseCase _updateTaskUseCase;
    private readonly IDeleteTaskUseCase _deleteTaskUseCase;

    public TaskController(ICreateTaskUseCase createTaskUseCase, IGetAllTaskUseCase getAllTaskUseCase, IGetTaskByIdUseCase getTaskByIdUseCase, IUpdateTaskUseCase updateTaskUseCase, IDeleteTaskUseCase deleteTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _getAllTaskUseCase = getAllTaskUseCase;
        _getTaskByIdUseCase = getTaskByIdUseCase;
        _updateTaskUseCase = updateTaskUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateTask), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestTask request)
    {
        var response = _createTaskUseCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTask), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = _getAllTaskUseCase.Execute();

        if (response.Tasks.Any())
            return Ok(response);
        
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var response = _getTaskByIdUseCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseUpdateTask), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] RequestTask request)
    {
        var response = _updateTaskUseCase.Execute(id, request);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status404NotFound)]
    public IActionResult DeleteById(Guid id)
    {
        _deleteTaskUseCase.Execute(id);

        return NoContent();
    }
}
