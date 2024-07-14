using AutoMapper;
using Core.Application.Exceptions.Types;
using Core.Utilities.JWT;
using MediatR;
using System.Security.Claims;
using System.Text.Json;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<AccessToken>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(x => x.Username == request.UserName && x.Password == request.Password);
            if (user == null)
                throw new CustomException("Giriş Başarısız");

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim("UserName", user.Username ?? string.Empty),
            };


            var token = _tokenHelper.CreateToken(new()
            {
                Claims = claims,
            });
           
            return token;
        }
    }
}
