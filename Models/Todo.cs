using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApplication.Models.Enum;

namespace ToDoListApplication.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Task name is required")]
        public string? TaskName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Deadline is required")]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public PriorityStatus Priority { get; set; } = PriorityStatus.Medium;
        public bool IsFinished { get; set; } = false;

        //one Category can have many todo items
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

    }


}
