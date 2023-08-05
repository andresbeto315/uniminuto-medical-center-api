using Application.Base;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.RegisterMedicalAppointment
{
    public class RegisterMedicalAppointmentRequest : IRequest<ResponseBase<RegisterMedicalAppointmentResponse>>
    {
        public int UserDoctorId { get; set; }
        public int UserPatientId { get; set; }
        public DateOnly Date { get; set; }
        public short StateId { get; set; }
        public string Observations { get; set; }
    }
}