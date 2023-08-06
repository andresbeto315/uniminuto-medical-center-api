namespace Domain.DTOs
{
    public class MedicalAppointmentDto
    {
        public long Id { get; set; }
        public int UserDoctorId { get; set; }
        public int UserPatientId { get; set; }
        public DateTime Date { get; set; }
        public short StateId { get; set; }
        public string Observations { get; set; }
    }
}