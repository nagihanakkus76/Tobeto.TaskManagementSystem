using AutoMapper;
using Core.Application.Exceptions.Types;
using MediatR;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.Application.Features.Tasks.Commands.Update;

public class UpdateTaskCommand : IRequest<UpdateTaskCommandResponse>
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTaskCommandResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? task = await _taskRepository.GetAsync(x => x.ID == request.ID);
            if (task == null) throw new CustomException("İstenilen kriterlere uygun veri bulunamadı");

            task.ID = request.ID;
            task.Title = request.Title;
            task.Description = request.Description;
            task.Status = request.Status;
            await _taskRepository.UpdateAsync(task);

            UpdateTaskCommandResponse response = _mapper.Map<UpdateTaskCommandResponse>(task);
            return response;
        }
    }
}