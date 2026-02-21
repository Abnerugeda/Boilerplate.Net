using AutoMapper;

namespace Application.UseCases.User.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, CreateUserResponse>();
    }
}