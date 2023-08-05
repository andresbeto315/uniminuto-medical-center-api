using Domain.Entities;

namespace Domain.Contracts.Persistence
{
    public interface IUserTypeRepository
    {
        IEnumerable<UserTypeEntity> GetAllUserType();
    }
}