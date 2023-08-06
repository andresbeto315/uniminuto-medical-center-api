using Application.Base;
using MediatR;

namespace Application.UsesCase.User.RegisterUser
{
    public class RegisterUserRequest : IRequest<ResponseBase<RegisterUserResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public short TypeId { get; set; }
    }
}