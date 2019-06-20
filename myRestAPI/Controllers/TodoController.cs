using Microsoft.AspNetCore.Authorization;
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
            todoService.CreateTodo(todoDTO);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            return todoService.GetTodo(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> Put(int id, [FromBody] TodoDTO todoDTO)
        {
            return todoService.Update(id, todoDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult<Todo> Delete(long id)
        {
            return todoService.DeleteTodo(id);
        }
    }
}
