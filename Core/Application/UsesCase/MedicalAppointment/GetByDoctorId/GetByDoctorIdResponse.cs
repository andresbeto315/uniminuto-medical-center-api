using Domain.DTOs;

namespace Application.UsesCase.MedicalAppointment.GetByDoctorId
{
    public class GetByDoctorIdResponse
    {
        public List<MedicalAppointmentDto> Medicals { get; set; }
    }
}