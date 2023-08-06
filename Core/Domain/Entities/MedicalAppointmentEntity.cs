using Domain.Base;

namespace Domain.Entities
{
    public class MedicalAppointmentEntity : BaseEntity
    {
        public long Id { get; set; }
        public int UserDoctorId { get; set; }
        public int UserPatientId { get; set; }
        public DateTime Date { get; set; }
        public short StateId { get; set; }
        public string Observations { get; set; }
    }
}