using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTOs.TaskItem
{
    public class TaskItemDto
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }
    }
}
