using Domain.Base;

namespace Domain.Entities
{
    public class UserTypeEntity : BaseEntity
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}