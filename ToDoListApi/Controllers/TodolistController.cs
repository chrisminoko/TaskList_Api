using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Context;
using ToDoListApi.Models;
using ToDoListApi.Repository;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodolistController : ControllerBase
    {
        private readonly  IDataRepository<TodoList> _dataRepository;
        public TodolistController(IDataRepository<TodoList> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var todolist = _dataRepository.GetAll();
            return Ok(todolist);
        }

        [HttpGet("{id}",Name ="GetLists")]
        public IActionResult Get( int id) 
        {
            var todolist = _dataRepository.Get(id);
            if (todolist==null) 
            {
                return NotFound("List not Found");
            }
            return Ok(todolist);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TodoList todoList)
        {
            if (todoList==null) 
            {
                return BadRequest("List is null");
            }
            _dataRepository.Add(todoList);
            return CreatedAtRoute("GetList", new { id = todoList.ListId }, null);

        }

        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody]TodoList todoList) 
        {
            if (todoList==null) 
            {
                return NotFound("The List is null");
            }
            var _listToUpdate = _dataRepository.Get(id);
            if (_listToUpdate == null) 
            {
                return NotFound("The list is not found");
            }
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            _dataRepository.Update(todoList);
            return NoContent();
        }
    }
}