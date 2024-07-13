using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(x => x.Username == request.UserName);
            if (user is not null) throw new Exception("Bu kullanıcı adıyla kayıt olunamaz.");
            
            user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user);

            RegisterResponse response = _mapper.Map<RegisterResponse>(user);

            return response;    
        }
    }
}
