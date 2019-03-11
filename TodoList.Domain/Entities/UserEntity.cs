using System.Collections.Generic;
using TodoList.Domain.Entities.Base;

namespace TodoList.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
