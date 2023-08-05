using Domain.Contracts.Persistence;
using Domain.Entities;
using Persistence.Base;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserTypeRepository : GenericRepository<UserTypeEntity>, IUserTypeRepository
    {
        public UserTypeRepository(MedicalCenterDbContext context) : base(context)
        {
        }

        public IEnumerable<UserTypeEntity> GetAllUserType()
        {
            return this.GetAll();
        }
    }
}