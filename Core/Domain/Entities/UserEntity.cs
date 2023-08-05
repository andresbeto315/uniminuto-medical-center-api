using Domain.Base;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public short TypeId { get; set; }
    }
}