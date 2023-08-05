using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence.Context
{
    public sealed class MedicalCenterDbContext : DbContext
    {
        public MedicalCenterDbContext(DbContextOptions<MedicalCenterDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalAppointmentConfiguration());
        }

        internal void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbSet<UserEntity> User { get; set; }

        public DbSet<UserTypeEntity> UserType { get; set; }

        public DbSet<StateEntity> State { get; set; }

        public DbSet<MedicalAppointmentEntity> MedicalAppointment { get; set; }
    }
}