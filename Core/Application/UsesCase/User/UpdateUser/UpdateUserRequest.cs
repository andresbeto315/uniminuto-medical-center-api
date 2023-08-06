using Application.Base;
using MediatR;

namespace Application.UsesCase.User.UpdateUser
{
    public class UpdateUserRequest : IRequest<ResponseBase<UpdateUserResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public short TypeId { get; set; }
    }
}