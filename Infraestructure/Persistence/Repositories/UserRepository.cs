using Domain.Contracts.Persistence;
using Domain.Entities;
using Persistence.Base;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MedicalCenterDbContext context) : base(context)
        {
        }

        public UserEntity GetById(int id)
        {
            var context = _db;
            var user = context.User
                .Where(t =>
                       t.Id == id &&
                       t.Active == true
                      )
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<UserEntity> GetUsers(string firstName, string lastName, short typeId)
        {
            var context = _db;
            var users = context.User
                .Where(t =>
                       t.TypeId == typeId &&
                       t.FirstName.Contains(firstName) &&
                       t.LastName.Contains(lastName) &&
                       t.Active == true
                      )
                .ToList();

            return users;
        }

        public IEnumerable<UserEntity> GetUsersByType(short typeId)
        {
            var context = _db;
            var users = context.User
                .Where(t =>
                       t.TypeId == typeId &&
                       t.Active == true
                      )
                .ToList();

            return users;
        }
    }
}