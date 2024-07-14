using AutoMapper;
using Core.Application.Exceptions.Types;
using MediatR;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Tasks.Queries.GetById;

public class GetByIdTaskQuery : IRequest<GetByIdTaskQueryResponse>
{
    public int ID { get; set; }

    public class GetByIdTaskQueryHandler : IRequestHandler<GetByIdTaskQuery, GetByIdTaskQueryResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetByIdTaskQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTaskQueryResponse> Handle(GetByIdTaskQuery request, CancellationToken cancellationToken)
        {
            TaskEntity? task = await _taskRepository.GetAsync(x => x.ID == request.ID);
            if (task is null) throw new CustomException("Aradığınız kritere göre veri bulunamadı");

            GetByIdTaskQueryResponse response = _mapper.Map<GetByIdTaskQueryResponse>(task);
            return response;
        }
    }
}