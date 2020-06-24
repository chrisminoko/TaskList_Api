using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Repository;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly IDataRepository<TaskList> _dataRepository;
        public TaskListController(IDataRepository<TaskList> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var _taskList = _dataRepository.GetAll();
            return Ok(_taskList);
        }
        [HttpPost]
        public IActionResult Post([FromBody]TaskList TaskList)
        {
            if (TaskList == null)
            {
                return BadRequest("List is null");
            }
            _dataRepository.Add(TaskList);
            return CreatedAtRoute("GetList", new { id = TaskList.ListId }, null);
        }
        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody]TaskList TaskList)
        {
            if (TaskList == null)
            {
                return NotFound("The List is null");
            }
            var _TaskListToUpdate = _dataRepository.Get(id);
            if (_TaskListToUpdate == null)
            {
                return NotFound("The list is not found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(TaskList);
            return NoContent();
        }
    }
}