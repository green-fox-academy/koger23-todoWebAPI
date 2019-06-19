using AutoMapper;
using myRestAPI.Models;
using System.Linq;
using myRestAPI.Profiles;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public Todo getTodo(long id)
        {
            return _context.Todos.Find(id);
        }

        public void deleteTodo(long id)
        {
            _context.Remove(_context.Todos.Find(id));
            _context.SaveChanges();
        }

        public void Update(int id, TodoDTO todoDTO)
        {
            Todo todo = _mapper.Map<TodoDTO, Todo>(todoDTO);
            todo.id = id;
            _context.Update(todo);
            _context.SaveChanges();
        }
    }
}
