using Domain.Contracts.Persistence;
using Domain.Entities;
using Persistence.Base;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class StateRepository : GenericRepository<StateEntity>, IStateRepository
    {
        public StateRepository(MedicalCenterDbContext context) : base(context)
        {
        }

        public IEnumerable<StateEntity> GetAllState()
        {
            return this.GetAll();
        }
    }
}