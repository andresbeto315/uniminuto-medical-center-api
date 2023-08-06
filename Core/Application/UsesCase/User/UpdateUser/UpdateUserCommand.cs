using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.User.UpdateUser
{
    public class UpdateUserCommand : IRequestHandler<UpdateUserRequest, ResponseBase<UpdateUserResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<UpdateUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = new UserEntity();
            this._mapper.Map<UpdateUserRequest, UserEntity>(request, newUser);
            var id = this._repository.Update(newUser);

            var response = new ResponseBase<UpdateUserResponse>
            {
                Data = new UpdateUserResponse
                {
                    Id = id
                },
                IDCodigo = 0,
                Message = "Modificado usuario de manera satisfactoria."
            };

            return Task.FromResult(response);
        }
    }
}