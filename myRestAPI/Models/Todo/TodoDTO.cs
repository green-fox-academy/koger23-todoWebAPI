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
        [Required(ErrorMessage = "Todo description is required")]
        public string description { get; set; }
        [Required(ErrorMessage = "Todo state is required")]
        public bool done { get; set; }
    }
}
