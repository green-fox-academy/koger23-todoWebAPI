using System.Collections.Generic;

namespace myRestAPI.Models
{
    public class TodoListDTO
    {
        public List<Todo> todoList { get; set; }

        public TodoListDTO()
        {
            this.todoList = new List<Todo>();
        }
    }
}
