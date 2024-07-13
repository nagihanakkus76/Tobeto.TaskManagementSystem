using AutoMapper;
using TaskManagementSystem.Application.Features.Auth.Commands.Register;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Auth.Profiles;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<User, RegisterCommand>().ReverseMap();
        CreateMap<User, RegisterResponse>().ReverseMap();
    }
}
