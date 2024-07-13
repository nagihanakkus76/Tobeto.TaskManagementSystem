using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Tasks.Queries.GetList;

public class GetListTaskQuery : IRequest<List<GetListTaskQueryResponse>>
{
    public class GetListTaskQueryHandler : IRequestHandler<GetListTaskQuery, List<GetListTaskQueryResponse>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetListTaskQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListTaskQueryResponse>> Handle(GetListTaskQuery request, CancellationToken cancellationToken)
        {
            List<TaskEntity> tasks = await _taskRepository.GetListAsync();
            List<GetListTaskQueryResponse> responses = _mapper.Map<List<GetListTaskQueryResponse>>(tasks);
            
            return responses;   
        }
    }
}