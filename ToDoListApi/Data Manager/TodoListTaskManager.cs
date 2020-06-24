using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Context;
using ToDoListApi.Models;
using ToDoListApi.Repository;

namespace ToDoListApi.Data_Manager
{
    public class TodoListTaskManager : IDataRepository<TodoList>
    {
        readonly TodoListContext _todoListContext;

        public TodoListTaskManager(TodoListContext todoListContext)
        {
            _todoListContext = todoListContext;
        }
        public void Add(TodoList entity)
        {
            _todoListContext.TodoLists.Add(entity);
        }

        public void Delete(TodoList entity)
        {
            _todoListContext.TodoLists.Remove(entity);
            _todoListContext.SaveChanges();
        }

        public TodoList Get(int id)
        {
            var _todList = _todoListContext.TodoLists
                .SingleOrDefault(x => x.ListId == id);
            return _todList;
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _todoListContext.TodoLists.ToList();
        }

        public void Update(TodoList entity)
        {
            _todoListContext.Entry(entity).State = EntityState.Added;
            _todoListContext.SaveChanges();
        }
    }
}
