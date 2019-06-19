using myRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        TodoListDTO FindAll();
        void createTodo(TodoDTO todoDTO);
        Todo TodoDTOConverter(TodoDTO todoDTO);
    }
}
