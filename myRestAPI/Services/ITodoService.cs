using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        string FindAll();
        Task CreateTodo(TodoDTO todoDTO);
        ActionResult<string> GetTodo(long id);
        Task<ActionResult<Todo>> DeleteTodo(long id);
        Task<ActionResult<Todo>> Update(int id, TodoDTO todoDTO);
        string SerializeObject(object obj);
    }
}
