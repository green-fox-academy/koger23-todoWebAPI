using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using myRestAPI.Models.Role;
using myRestAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public List<TodoGetDTO> Get()
        {
            return todoService.FindAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoDTO todoDTO)
        {
            return await todoService.CreateTodo(todoDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoGetDTO> Get(long id)
        {
            return todoService.GetTodo(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Put(int id, [FromBody] TodoDTO todoDTO)
        {
            return await todoService.Update(id, todoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> Delete(long id)
        {
            return await todoService.DeleteTodo(id);
        }
    }
}
