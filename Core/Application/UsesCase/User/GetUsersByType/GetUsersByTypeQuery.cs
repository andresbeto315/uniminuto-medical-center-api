using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.User.GetUsersByType
{
    internal class GetUsersByTypeQuery : IRequestHandler<GetUsersByTypeRequest, ResponseBase<GetUsersByTypeResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersByTypeQuery(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetUsersByTypeResponse>> Handle(GetUsersByTypeRequest request, CancellationToken cancellationToken)
        {
            var users = this._userRepository.GetUsersByType(request.TypeId);
            var response = new ResponseBase<GetUsersByTypeResponse>
            {
                Data = new GetUsersByTypeResponse
                {
                    Users = new List<UserDto>()
                },
                IDCodigo = 0,
                Message = "Búsqueda de usuarios satisfactoria."
            };
            foreach (var user in users)
            {
                var newUser = new UserDto();
                response.Data.Users.Add(this._mapper.Map<UserEntity, UserDto>(user, newUser));
            }

            return Task.FromResult(response);
        }
    }
}