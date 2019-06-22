using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        public List<TodoGetDTO> FindAll()
        {
            var todoList = _context.Todos.ToList();
            var todoGetDTOList = new List<TodoGetDTO>();
            foreach (Todo todo in todoList)
            {
                todoGetDTOList.Add(_mapper.Map<Todo, TodoGetDTO>(todo));
            }
            return todoGetDTOList;
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

        public ActionResult<TodoGetDTO> GetTodo(long id)
        {
            Todo todo = _context.Todos
                .Where(t => t.Id == id)
                .SingleOrDefault();
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            return _mapper.Map<Todo, TodoGetDTO>(todo); ;
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
