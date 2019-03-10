using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TodoList.Domain.Entities.Base;

namespace TodoList.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public int? UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
