using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ToDoListApi.Models
{
    public class TaskList
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        [ForeignKey(nameof(List))]
        public int ListId { get; set; }
        public virtual TodoList List { get; set; }
    }
}
