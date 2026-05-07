namespace TaskManagement.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }
    }
}
