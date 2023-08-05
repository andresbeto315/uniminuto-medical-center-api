using Application.Base;
using MediatR;

namespace Application.UsesCase.User.GetUserById
{
    public class GetUserByIdRequest : IRequest<ResponseBase<GetUserByIdResponse>>
    {
        public int Id { get; set; }
    }
}