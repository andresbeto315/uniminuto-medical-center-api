using Application.Base;
using MediatR;

namespace Application.UsesCase.State.GetAllState
{
    public class GetAllStateRequest : IRequest<ResponseBase<GetAllStateResponse>>
    {
    }
}