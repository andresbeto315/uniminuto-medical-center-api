using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configuration
{
    public class MedicalAppointmentConfiguration : IEntityTypeConfiguration<MedicalAppointmentEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointmentEntity> builder)
        {
            builder.ToTable("medical_appointment");
            builder.HasKey(m => m.Id);
        }
    }
}