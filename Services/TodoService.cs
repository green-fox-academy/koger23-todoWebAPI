using myRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public class TodoService
    {
        private ApplicationContext _context;

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
    }
}
