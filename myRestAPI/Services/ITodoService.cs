using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        TodoListDTO FindAll();
        void CreateTodo(TodoDTO todoDTO);
        Todo TodoDTOConverter(TodoDTO todoDTO);
        ActionResult<string> GetTodo(long id);
        ActionResult<Todo> DeleteTodo(long id);
        ActionResult<Todo> Update(int id, TodoDTO todoDTO);
        string SerializeObject(object obj);
    }
}
