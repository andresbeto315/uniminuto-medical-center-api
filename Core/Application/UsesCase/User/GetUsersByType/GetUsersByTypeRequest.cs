using Application.Base;
using MediatR;

namespace Application.UsesCase.User.GetUsersByType
{
    public class GetUsersByTypeRequest : IRequest<ResponseBase<GetUsersByTypeResponse>>
    {
        public short TypeId { get; set; }
    }
}