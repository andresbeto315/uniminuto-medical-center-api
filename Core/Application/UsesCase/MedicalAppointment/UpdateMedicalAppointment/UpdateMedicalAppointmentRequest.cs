using Application.Base;
using MediatR;

namespace Application.UsesCase.MedicalAppointment.UpdateMedicalAppointment
{
    public class UpdateMedicalAppointmentRequest : IRequest<ResponseBase<UpdateMedicalAppointmentResponse>>
    {
        public long Id { get; set; }
        public int UserDoctorId { get; set; }
        public int UserPatientId { get; set; }
        public DateTime Date { get; set; }
        public short StateId { get; set; }
        public string Observations { get; set; }
    }
}