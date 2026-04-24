using TaskManagement.Entities;

namespace TaskManagement.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllTaskItemsAsync();
        Task<TaskItem?> GetTaskItemByIdAsync(int taskId);
        Task<TaskItem?> CreateTaskItemAsync(TaskItem taskItem);
        Task<TaskItem?> UpdateTaskItemAsync(int taskId, TaskItem taskItem);
        Task<bool> DeleteTaskItemAsync(int taskId);
    }
}