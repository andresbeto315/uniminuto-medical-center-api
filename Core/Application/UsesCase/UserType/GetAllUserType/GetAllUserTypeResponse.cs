using Domain.DTOs;

namespace Application.UsesCase.UserType.GetAllUserType
{
    public class GetAllUserTypeResponse
    {
        public List<UserTypeDto> UserTypes { get; set; }
    }
}