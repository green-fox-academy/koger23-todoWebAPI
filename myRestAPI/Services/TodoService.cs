using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using Newtonsoft.Json;
using System.Linq;

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

        public void CreateTodo(TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.Assignee = _context.Assignees.Find(todoDTO.AssigneeId);
            _context.Add(todo);
            _context.SaveChanges();
        }

        public Todo TodoDTOConverter(TodoDTO todoDTO)
        {
            Todo newTodo = new Todo();
            newTodo.Name = todoDTO.Name;
            newTodo.Description = todoDTO.Description;
            Assignee assignee = _context.Assignees.SingleOrDefault(a => a.Id == todoDTO.AssigneeId);
            newTodo.Assignee = assignee;
            return newTodo;
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

        public ActionResult<Todo> DeleteTodo(long id)
        {
            Todo todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            _context.Remove(_context.Todos.Find(id));
            _context.SaveChanges();
            return new OkResult();
        }

        public ActionResult<Todo> Update(int id, TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.Id = id;
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            _context.Update(todo);
            _context.SaveChanges();
            return new OkResult();
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
        }
    }
}
