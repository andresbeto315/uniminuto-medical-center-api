using Domain.Entities;

namespace Domain.Contracts.Persistence
{
    public interface IMedicalAppointmentRepository
    {
        IEnumerable<MedicalAppointmentEntity> GetByPatientId(int userPatientId);
        IEnumerable<MedicalAppointmentEntity> GetByDoctorId(int userDoctorId);
        MedicalAppointmentEntity GetById(long id);
        long Register(MedicalAppointmentEntity entity);
        long Update(MedicalAppointmentEntity entity);
        long Delete(long id);
    }
}