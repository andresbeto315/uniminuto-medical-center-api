using Application.Base;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.GetByPatientId
{
    public class GetByPatientIdRequest : IRequest<ResponseBase<GetByPatientIdResponse>>
    {
        public int PatientId { get; set; }
    }
}