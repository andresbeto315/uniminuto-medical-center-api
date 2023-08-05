using Application.Base;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.GetMedicalAppointmentById
{
    public class GetMedicalAppointmentByIdRequest : IRequest<ResponseBase<GetMedicalAppointmentByIdResponse>>
    {
        public long Id { get; set; }
    }
}