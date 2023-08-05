using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configuration
{
    public class UserTypeEntityConfiguration : IEntityTypeConfiguration<UserTypeEntity>
    {
        public void Configure(EntityTypeBuilder<UserTypeEntity> builder)
        {
            builder.ToTable("user_type");
            builder.HasKey(ut => ut.Id);
        }
    }
}