using TaskManagement.DTOs.TaskItem;
using TaskManagement.Entities;

namespace TaskManagement.Mappers
{
    public static class TaskItemDtoMapper
    {
        public static TaskItemDto ToTaskItemDto (this TaskItem taskItem)
        {
            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                CreatedOn = taskItem.CreatedOn,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                UserId = taskItem.UserId
            };
        }

        public static TaskItem ToTaskItem(this TaskItemRequestDto taskItemDto)
        {
            return new TaskItem
            {
                Title = taskItemDto.Title,
                CreatedOn = DateTime.UtcNow,
                Description = taskItemDto.Description,
                IsCompleted = taskItemDto.IsCompleted
            };
        }
    }
}
