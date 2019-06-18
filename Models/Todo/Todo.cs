using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Models
{
    public class Todo
    {
        public long id { get; set; }
        public string name { get; set; }
        public Assignee assignee { get; set; }
        public string description { get; set; }
        public Boolean done { get; set; }

        public Todo()
        {
            this.done = false;
        }

        public Todo(string name, Assignee assignee, string description)
        {
            this.name = name;
            this.assignee = assignee;
            this.description = description;
            this.done = false;
        }

        public Todo(long id, string name, Assignee assignee, string description, bool done)
        {
            this.id = id;
            this.name = name;
            this.assignee = assignee;
            this.description = description;
            this.done = done;
        }
    }
}
