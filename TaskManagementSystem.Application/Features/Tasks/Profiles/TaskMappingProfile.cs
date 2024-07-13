using AutoMapper;
using TaskManagementSystem.Application.Features.Tasks.Commands.ChangeStatus;
using TaskManagementSystem.Application.Features.Tasks.Commands.Create;
using TaskManagementSystem.Application.Features.Tasks.Commands.Update;
using TaskManagementSystem.Application.Features.Tasks.Queries.GetById;
using TaskManagementSystem.Application.Features.Tasks.Queries.GetList;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Tasks.Profiles;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<TaskEntity, CreateTaskCommand>().ReverseMap();
        CreateMap<TaskEntity, CreateTaskCommandResponse>().ReverseMap();

        CreateMap<TaskEntity, UpdateTaskCommand>().ReverseMap();
        CreateMap<TaskEntity, UpdateTaskCommandResponse>().ReverseMap();

        CreateMap<TaskEntity, GetByIdTaskQueryResponse>().ReverseMap();

        CreateMap<TaskEntity, GetListTaskQueryResponse>().ReverseMap();

        CreateMap<TaskEntity, ChangeStatusTaskCommandResponse>().ReverseMap();
    }
}
