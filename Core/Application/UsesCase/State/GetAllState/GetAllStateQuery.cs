using Application.Base;
using Domain.Contracts.Adapter.IMapper;
using Domain.Contracts.Persistence;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.UsesCase.State.GetAllState
{
    public class GetAllStateQuery : IRequestHandler<GetAllStateRequest, ResponseBase<GetAllStateResponse>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public GetAllStateQuery(IStateRepository stateRepository, IMapper mapper)
        {
            this._stateRepository = stateRepository;
            this._mapper = mapper;
        }

        public Task<ResponseBase<GetAllStateResponse>> Handle(GetAllStateRequest request, CancellationToken cancellationToken)
        {
            var states = this._stateRepository.GetAllState();
            var response = new ResponseBase<GetAllStateResponse>
            {
                Data = new GetAllStateResponse
                {
                    States = new List<StateDto>()
                },
                IDCodigo = 0,
                Message = "Búsqueda de estados satisfactoria."
            };
            foreach (var state in states)
            {
                var newState = new StateDto();
                response.Data.States.Add(this._mapper.Map<StateEntity, StateDto>(state, newState));
            } 
            return Task.FromResult(response);
        }
    }
}