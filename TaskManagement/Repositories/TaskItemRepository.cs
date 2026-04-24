using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Entities;
using TaskManagement.Interfaces;

namespace TaskManagement.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<TaskItem>> GetAllTaskItemsAsync() => 
            await _appDbContext.TaskItems.ToListAsync();

        public async Task<TaskItem?> GetTaskItemByIdAsync(int taskId) =>
           await _appDbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == taskId);


        public async Task<TaskItem?> CreateTaskItemAsync(TaskItem taskItem)
        {
            await _appDbContext.TaskItems.AddAsync(taskItem);
            await _appDbContext.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> DeleteTaskItemAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskItem?> UpdateTaskItemAsync(int taskId, TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
