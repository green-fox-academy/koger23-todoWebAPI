using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public TodoListDTO FindAll()
        {
            TodoListDTO todoListDTO = new TodoListDTO();
            todoListDTO.todoList = _context.Todos.ToList();
            return todoListDTO;
        }

        public async Task CreateTodo(TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.Assignee = _context.Assignees.Find(todoDTO.AssigneeId);
            _context.Add(todo);
            await _context.SaveChangesAsync();
        }

        public ActionResult<string> GetTodo(long id)
        {
            Todo todo = _context.Todos
                .Single(t => t.Id == id);
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            _context.Entry(todo)
                .Reference(t => t.Assignee)
                .Load();
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
