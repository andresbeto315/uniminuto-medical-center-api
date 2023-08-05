using Domain.DTOs;

namespace Application.UsesCase.MedicalAppointment.GetByPatientId
{
    public class GetByPatientIdResponse
    {
        public List<MedicalAppointmentDto> Medicals { get; set; }
    }
}