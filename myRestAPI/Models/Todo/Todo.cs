using myRestAPI.Models;

namespace myRestAPI.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Assignee Assignee { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public User.User Creator { get; }
    }
}
