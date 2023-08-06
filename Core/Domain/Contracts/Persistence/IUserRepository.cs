using Domain.Entities;

namespace Domain.Contracts.Persistence
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetUsers(string firstName, string lastName, short typeId);
        IEnumerable<UserEntity> GetUsersByType(short typeId);
        int Register(UserEntity entity);
        int Update(UserEntity entity);
        UserEntity GetById(int id);
    }
}