namespace myRestAPI.Models
{
    public class Todo
    {
        public long id { get; set; }
        public string name { get; set; }
        public Assignee assignee { get; set; }
        public string description { get; set; }
        public bool done { get; set; }
    }
}
