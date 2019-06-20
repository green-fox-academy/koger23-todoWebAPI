using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myRestAPI.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public TodoService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string FindAll()
        {
            TodoListDTO todoListDTO = new TodoListDTO();
            var todos = _context.Todos
                .Include(i => i.Assignee)
                .Include(t => t.Creator);
            todoListDTO.todoList = todos.ToList();
            return SerializeObject(todoListDTO);
        }

        public async Task<IActionResult> CreateTodo(TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.Assignee = _context.Assignees.Find(todoDTO.AssigneeId);
            todo.Creator = _context.Users.Find(todoDTO.UserId);
            if (todo.Assignee == null || todo.Creator == null)
            {
                return new BadRequestResult();
            }
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public ActionResult<string> GetTodo(long id)
        {
            Todo todo = _context.Todos
                .Include(i => i.Assignee)
                .Include(t => t.Creator)
                .Single(t => t.Id == id);
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            return SerializeObject(todo);
        }

        public async Task<ActionResult<Todo>> DeleteTodo(long id)
        {
            Todo todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            _context.Remove(_context.Todos.Find(id));
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<ActionResult<Todo>> Update(int id, TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.Id = id;
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            if (todo.Assignee == null || todo.Creator == null)
            {
                return new BadRequestResult();
            }
            _context.Update(todo);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public string SerializeObject(object obj)
        {
            string output = JsonConvert.SerializeObject(obj, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return output;
        }
    }
}
