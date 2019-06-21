namespace myRestAPI.Models
{
    public class TodoGetDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AssigneeId { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public long UserId { get; set; }

        public TodoGetDTO()
        {
        }
    }
}
