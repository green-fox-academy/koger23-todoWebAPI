using Microsoft.EntityFrameworkCore.ChangeTracking;
using myRestAPI.Models;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        TodoListDTO FindAll();
        void createTodo(TodoDTO todoDTO);
        Todo TodoDTOConverter(TodoDTO todoDTO);
        Todo getTodo(long id);
        void deleteTodo(long id);
        void Update(int id, TodoDTO todoDTO);
    }
}
