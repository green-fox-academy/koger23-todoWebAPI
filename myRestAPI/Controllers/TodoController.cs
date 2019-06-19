﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using myRestAPI.Services;

namespace myRestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;

        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public TodoListDTO Get()
        {
            return todoService.FindAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoDTO todoDTO)
        {
            todoService.createTodo(todoDTO);
            return Ok();
        }

        [HttpGet("{id}")]
        public Todo Get(long id)
        {
            Todo todo = todoService.getTodo(id);
            return todo;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
