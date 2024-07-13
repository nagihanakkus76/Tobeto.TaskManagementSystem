using AutoMapper;
using MediatR;
using System.Security.Cryptography.X509Certificates;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.Application.Features.Tasks.Commands.ChangeStatus;

public class ChangeStatusTaskCommand :IRequest<ChangeStatusTaskCommandResponse>
{
    public int ID { get; set; }
    public Status Status { get; set; }

    public class ChangeStatusTaskCommandHandler : IRequestHandler<ChangeStatusTaskCommand, ChangeStatusTaskCommandResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ChangeStatusTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<ChangeStatusTaskCommandResponse> Handle(ChangeStatusTaskCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? task = await _taskRepository.GetAsync(x => x.ID == request.ID);
            if (task == null) throw new Exception("İstenilen kriterlere uygun veri bulunamadı.");

            task.Status = request.Status;
            await _taskRepository.UpdateAsync(task);

            ChangeStatusTaskCommandResponse response = _mapper.Map<ChangeStatusTaskCommandResponse>(task);
            return response;
        }
    }
}