using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.User.GetUserById
{
    public class GetUserByIdQuery : IRequestHandler<GetUserByIdRequest, ResponseBase<GetUserByIdResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetUserByIdResponse>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = this._userRepository.GetById(request.Id);
            var newUser = new UserDto();
            var response = new ResponseBase<GetUserByIdResponse>
            {
                Data = new GetUserByIdResponse
                {
                    User = this._mapper.Map<UserEntity, UserDto>(user, newUser)
                },
                IDCodigo = 0,
                Message = "Búsqueda de estados satisfactoria."
            };

            return Task.FromResult(response);
        }
    }
}