using Domain.Entities;

namespace Domain.Contracts.Persistence
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetUsers(string firstName, string lastName, short typeId);
        IEnumerable<UserEntity> GetUsersByType(short typeId);
        UserEntity GetById(int id);
    }
}