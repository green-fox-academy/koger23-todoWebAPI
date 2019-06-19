using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        TodoListDTO FindAll();
        void createTodo(TodoDTO todoDTO);
        Todo TodoDTOConverter(TodoDTO todoDTO);
        ActionResult<Todo> getTodo(long id);
        ActionResult<Todo> deleteTodo(long id);
        ActionResult<Todo> Update(int id, TodoDTO todoDTO);
    }
}
