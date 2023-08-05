using Application.Base;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.GetByDoctorId
{
    public class GetByDoctorIdRequest : IRequest<ResponseBase<GetByDoctorIdResponse>>
    {
        public int DoctorId { get; set; }
    }
}