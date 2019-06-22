using System.Collections.Generic;

namespace myRestAPI.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public ICollection<Todo> TodoList { get; set; }
        public ICollection<Assignee.Assignee> AssigneeList { get; set; }

        public User()
        {
        }
    }
}
