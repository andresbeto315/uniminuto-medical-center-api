using Application.Base;
using MediatR;

namespace Application.UsesCase.UserType.GetAllUserType
{
    public class GetAllUserTypeRequest : IRequest<ResponseBase<GetAllUserTypeResponse>>
    {
    }
}