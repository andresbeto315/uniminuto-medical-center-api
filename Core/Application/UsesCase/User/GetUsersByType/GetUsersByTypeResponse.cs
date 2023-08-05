using Domain.DTOs;

namespace Application.UsesCase.User.GetUsersByType
{
    public class GetUsersByTypeResponse
    {
        public List<UserDto> Users { get; set; }
    }
}