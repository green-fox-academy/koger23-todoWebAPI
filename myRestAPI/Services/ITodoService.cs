using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public interface ITodoService
    {
        List<TodoGetDTO> FindAll();
        Task<IActionResult> CreateTodo(TodoDTO todoDTO);
        ActionResult<TodoGetDTO> GetTodo(long id);
        Task<ActionResult<Todo>> DeleteTodo(long id);
        Task<ActionResult<Todo>> Update(int id, TodoDTO todoDTO);
        string SerializeObject(object obj);
    }
}
