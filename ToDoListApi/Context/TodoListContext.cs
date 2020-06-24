using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
    }
}
