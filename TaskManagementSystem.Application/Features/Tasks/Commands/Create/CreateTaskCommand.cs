using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Tasks.Commands.Create;

public class CreateTaskCommand : IRequest<CreateTaskCommandResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserID { get; set; }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            TaskEntity task = _mapper.Map<TaskEntity>(request);

            await _taskRepository.AddAsync(task);

            CreateTaskCommandResponse response = _mapper.Map<CreateTaskCommandResponse>(task);
            return response;
        }
    }
}
