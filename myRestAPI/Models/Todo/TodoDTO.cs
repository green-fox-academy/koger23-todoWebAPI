using System.ComponentModel.DataAnnotations;

namespace myRestAPI.Models
{
    public class TodoDTO
    {
        [Required(ErrorMessage = "Todo name is required")]
        [StringLength(160)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Assignee ID is required")]
        public long AssigneeId { get; set; }
        [Required(ErrorMessage = "Todo description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Todo state is required")]
        public bool Done { get; set; }
        public int UserId { get; set; }
    }
}
