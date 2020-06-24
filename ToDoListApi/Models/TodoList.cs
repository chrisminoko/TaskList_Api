using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApi.Models
{
    public class TodoList
    {
        [Key]
        public int ListId { get; set; }
        public string Title { get; set; }
        public ICollection<TaskList> Tasks { get; set; }
    }
}
