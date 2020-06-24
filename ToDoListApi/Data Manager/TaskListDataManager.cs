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
    public class TaskListDataManager : IDataRepository<TaskList>
    {
        readonly TodoListContext _todoListContext;
        public TaskListDataManager(TodoListContext todoListContext )
        {
            _todoListContext = todoListContext;
        }
        public void Add(TaskList entity)
        {
            _todoListContext.TaskLists.Add(entity);
            _todoListContext.SaveChanges();
        }
        public void Delete(TaskList entity)
        {
            _todoListContext.TaskLists.Remove(entity);
        }
        public TaskList Get(int id)
        {
            var _taskList = _todoListContext.TaskLists
                   .SingleOrDefault(x => x.TaskId == id);
            return _taskList;
        }

        public IEnumerable<TaskList> GetAll()
        {
            return _todoListContext.TaskLists.ToList();
        }
        public void Update( TaskList entity)
        {
            _todoListContext.Entry(entity).State = EntityState.Added;
            _todoListContext.SaveChanges();
        }
    }
}
