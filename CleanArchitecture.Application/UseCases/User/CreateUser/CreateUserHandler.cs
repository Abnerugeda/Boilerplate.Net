using AutoMapper;
using Domain.Interfaces;
using MediatR;
using UserEntity = Domain.Entities.User;

namespace Application.UseCases.User.CreateUser;

public class CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
    : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly  IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<UserEntity>(request);
        _userRepository.Create(user);

        await _unitOfWork.Commmit(cancellationToken);
        
        return _mapper.Map<CreateUserResponse>(user);
    }
}   