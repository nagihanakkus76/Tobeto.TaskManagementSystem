using Core.Application.Exceptions.Types;
using MediatR;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Tasks.Commands.Delete;

public class DeleteTaskCommand : IRequest
{
    public int ID { get; set; }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? task = await _taskRepository.GetAsync(x => x.ID == request.ID);
            if (task == null) throw new CustomException("Silmek istediğiniz veri bulunamadı");

            await _taskRepository.DeleteAsync(task);
        }
    }
}