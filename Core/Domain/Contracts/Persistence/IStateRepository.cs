using Domain.Entities;

namespace Domain.Contracts.Persistence
{
    public interface IStateRepository
    {
        IEnumerable<StateEntity> GetAllState();
    }
}