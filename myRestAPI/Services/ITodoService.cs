using myRestAPI.Models;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        TodoListDTO FindAll();
        void createTodo(TodoDTO todoDTO);
        Todo TodoDTOConverter(TodoDTO todoDTO);
    }
}
