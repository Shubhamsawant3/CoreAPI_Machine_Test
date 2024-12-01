using Microsoft.AspNetCore.Mvc;
using CoreAPI_Machine_Test.Models;
using CoreAPI_Machine_Test.Services;

namespace CoreAPI_Machine_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks([FromQuery] string? status, [FromQuery] DateTime? dueDate, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var tasks = _taskService.GetAllTasks(status, dueDate, page, pageSize);
            var result = tasks.Select(t => new
            {
                t.Id,
                Status = t.Status.ToString(),
                t.DueDate,
                t.Title,
                t.Description
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            var result = new
            {
                task.Id,
                Status = task.Status.ToString(), 
                task.DueDate,
                task.Title,
                task.Description
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            if (!Enum.IsDefined(typeof(Models.TaskStatus), task.Status))
            {
                return BadRequest("Invalid status value. Allowed values are 0 (Pending), 1 (InProgress), or 2 (Completed).");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTask = _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskItem task)
        {
            if (!Enum.IsDefined(typeof(Models.TaskStatus), task.Status))
            {
                return BadRequest("Invalid status value. Allowed values are 0 (Pending), 1 (InProgress), or 2 (Completed).");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTask = _taskService.UpdateTask(id, task);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (!_taskService.DeleteTask(id)) return NotFound();
            return NoContent();
        }
    }
}
