using Infrastructure;
using Task.Api.Middlewares;
using Task.Application.Interfaces;
using Task.Application.UseCases.Task.Create;
using Task.Application.UseCases.Task.Delete;
using Task.Application.UseCases.Task.GetAll;
using Task.Application.UseCases.Task.GetById;
using Task.Application.UseCases.Task.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddSingleton<ICreateTaskUseCase, CreateTaskUseCase>();
builder.Services.AddSingleton<IGetAllTaskUseCase, GetAllTaskUseCase>();
builder.Services.AddSingleton<IGetTaskByIdUseCase, GetTaskByIdUseCase>();
builder.Services.AddSingleton<IUpdateTaskUseCase, UpdateTaskUseCase>();
builder.Services.AddSingleton<IDeleteTaskUseCase, DeleteTaskUseCase>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
