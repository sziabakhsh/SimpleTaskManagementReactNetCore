using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTOs.TaskItem;
using TaskManagement.Interfaces;
using TaskManagement.Mappers;
using System.Security.Claims;

namespace TaskManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {

        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemController(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllTaskItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var taskItems = await _taskItemRepository.GetAllTaskItemsAsync(userId);
            return Ok(taskItems.Select(t => t.ToTaskItemDto()));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTaskItemById(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var taskItem = await _taskItemRepository.GetTaskItemByIdAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            else
            {
                if (taskItem.UserId != userId)
                {
                    return Forbid();
                }
            }
            return Ok(taskItem.ToTaskItemDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] TaskItemRequestDto taskItemDto)
        {
            var taskItem = taskItemDto.ToTaskItem();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            taskItem.UserId = userId;

            var createdTaskItem = await _taskItemRepository.CreateTaskItemAsync(taskItem);
            if (createdTaskItem == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetTaskItemById), new { id = createdTaskItem.Id }, createdTaskItem.ToTaskItemDto());
        }

        //[HttpPut("{id}")]
        //[HttpDelete("{id}")]

    }
}
