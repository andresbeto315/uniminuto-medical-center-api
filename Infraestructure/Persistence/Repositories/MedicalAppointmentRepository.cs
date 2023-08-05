using Domain.Contracts.Persistence;
using Domain.Entities;
using Persistence.Base;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class MedicalAppointmentRepository : GenericRepository<MedicalAppointmentEntity>, IMedicalAppointmentRepository
    {
        public MedicalAppointmentRepository(MedicalCenterDbContext context) : base(context)
        {
        }

        public long Delete(long id)
        {
            return this.Delete(id);
        }

        public IEnumerable<MedicalAppointmentEntity> GetByDoctorId(int userDoctorId)
        {
            var context = _db;
            var medicals = context.MedicalAppointment
                .Where(t =>
                       t.UserDoctorId == userDoctorId
                      )
                .ToList();

            return medicals;
        }

        public MedicalAppointmentEntity GetById(long id)
        {
            return this.Find(id);
        }

        public IEnumerable<MedicalAppointmentEntity> GetByPatientId(int userPatientId)
        {
            var context = _db;
            var medicals = context.MedicalAppointment
                .Where(t =>
                       t.UserPatientId == userPatientId
                      )
                .ToList();

            return medicals;
        }

        public long Register(MedicalAppointmentEntity entity)
        {
            this.Add(entity);
            return 0;
        }

        public long Update(MedicalAppointmentEntity entity)
        {
            this.Edit(entity);
            return 0;
        }
    }
}