using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.User.RegisterUser
{
    public class RegisterUserCommand : IRequestHandler<RegisterUserRequest, ResponseBase<RegisterUserResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public RegisterUserCommand(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = new UserEntity();
            this._mapper.Map<RegisterUserRequest, UserEntity>(request, newUser);
            var id = this._repository.Register(newUser);

            var response = new ResponseBase<RegisterUserResponse>
            {
                Data = new RegisterUserResponse
                {
                    Id = id
                },
                IDCodigo = 0,
                Message = "Creado usuario de manera satisfactoria."
            };

            return Task.FromResult(response);
        }
    }
}