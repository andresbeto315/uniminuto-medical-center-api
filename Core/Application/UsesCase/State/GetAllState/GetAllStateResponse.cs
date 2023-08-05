using Domain.DTOs;

namespace Application.UsesCase.State.GetAllState
{
    public class GetAllStateResponse
    {
        public List<StateDto> States { get; set; }
    }
}