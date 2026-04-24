using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTOs.TaskItem;
using TaskManagement.Interfaces;
using TaskManagement.Mappers;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {

        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemController(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskItems()
        {
            var taskItems = await _taskItemRepository.GetAllTaskItemsAsync();
            return Ok(taskItems.Select(t => t.ToTaskItemDto()));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTaskItemById(int id)
        {
            var taskItem = await _taskItemRepository.GetTaskItemByIdAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return Ok(taskItem.ToTaskItemDto());
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateTaskItem([FromBody] TaskItemRequestDto taskItemDto)
        {
            var taskItem = taskItemDto.ToTaskItem();
            var createdTaskItem = await _taskItemRepository.CreateTaskItemAsync(taskItem);
            if (createdTaskItem == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetTaskItemById), new { id = createdTaskItem.Id }, createdTaskItem.ToTaskItemDto());
        }


    }
}
