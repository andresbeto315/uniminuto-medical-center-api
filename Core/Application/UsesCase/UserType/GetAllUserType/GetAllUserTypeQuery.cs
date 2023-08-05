using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.UserType.GetAllUserType
{
    public class GetAllUserTypeQuery : IRequestHandler<GetAllUserTypeRequest, ResponseBase<GetAllUserTypeResponse>>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public GetAllUserTypeQuery(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            this._userTypeRepository = userTypeRepository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetAllUserTypeResponse>> Handle(GetAllUserTypeRequest request, CancellationToken cancellationToken)
        {
            var types = this._userTypeRepository.GetAllUserType();
            var response = new ResponseBase<GetAllUserTypeResponse>
            {
                Data = new GetAllUserTypeResponse
                {
                    UserTypes = new List<UserTypeDto>()
                },
                IDCodigo = 0,
                Message = "Búsqueda de estados satisfactoria."
            };
            foreach (var type in types)
            {
                var newType = new UserTypeDto();
                response.Data.UserTypes.Add(this._mapper.Map<UserTypeEntity, UserTypeDto>(type, newType));
            }
            return Task.FromResult(response);
        }
    }
}