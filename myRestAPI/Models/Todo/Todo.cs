namespace myRestAPI.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AssigneeId { get; set; }
        public Assignee Assignee { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public long UserId { get; set; }
        public User.User Creator { get; set; }

        public Todo()
        {
        }
    }
}
