using System.ComponentModel.DataAnnotations;

namespace myRestAPI.Models
{
    public class TodoDTO
    {
        [Required(ErrorMessage = "Todo name is required")]
        [StringLength(160)]
        public string name { get; set; }
        [Required(ErrorMessage = "Assignee ID is required")]
        public long assigneeId { get; set; }
        public string description { get; set; }

        public TodoDTO(string name, long assigneeId, string description = "")
        {
            this.name = name;
            this.assigneeId = assigneeId;
            this.description = description;
        }
    }
}
