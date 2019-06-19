using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public void Put(int id, [FromBody] TodoDTO todoDTO)
        {
            todoService.Update(id, todoDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            todoService.deleteTodo(id);
            return NoContent();
        }
    }
}
