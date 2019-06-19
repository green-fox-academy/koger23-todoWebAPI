using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
