using System.Collections.Generic;

namespace myRestAPI.Models
{
    public class Assignee
    {
        public long id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public ICollection<Todo> Student { get; set; }
    }
}