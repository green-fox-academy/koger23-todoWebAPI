using System.Collections.Generic;

namespace myRestAPI.Models
{
    public class Assignee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Todo> TodoList { get; set; }
    }
}