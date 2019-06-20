using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
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

        public void createTodo(TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.assignee = _context.Assignees.Find(todoDTO.assigneeId);
            _context.Add(todo);
            _context.SaveChanges();
        }

        public Todo TodoDTOConverter(TodoDTO todoDTO)
        {
            Todo newTodo = new Todo();
            newTodo.name = todoDTO.name;
            newTodo.description = todoDTO.description;
            Assignee assignee = _context.Assignees.SingleOrDefault(a => a.id == todoDTO.assigneeId);
            newTodo.assignee = assignee;
            return newTodo;
        }

        public ActionResult<Todo> getTodo(long id)
        {
            Todo todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return new NotFoundObjectResult("Todo not found with this id.");
            }
            return todo;
        }

        public ActionResult<Todo> deleteTodo(long id)
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
            todo.id = id;
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
