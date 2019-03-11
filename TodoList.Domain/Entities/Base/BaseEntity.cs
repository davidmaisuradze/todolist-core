using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
