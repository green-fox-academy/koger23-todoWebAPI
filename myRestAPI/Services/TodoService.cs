using myRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationContext _context;

        public TodoService(ApplicationContext context)
        {
            _context = context;
        }

        public TodoListDTO FindAll()
        {
            TodoListDTO todoListDTO = new TodoListDTO();
            todoListDTO.todoList = _context.Todos.ToList();
            return todoListDTO;
        }

        public void createTodo(TodoDTO todoDTO)
        {
            _context.Add(TodoDTOConverter(todoDTO));
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
    }
}
