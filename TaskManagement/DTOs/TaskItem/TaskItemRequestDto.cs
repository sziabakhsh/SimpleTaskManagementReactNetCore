using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTOs.TaskItem
{
    public class TaskItemRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
