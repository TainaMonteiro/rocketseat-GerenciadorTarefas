using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public ActionResult<Task> Create(Task task)
    {
        _taskService.Create(task);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpGet]
    public ActionResult<List<Task>> GetAll() => _taskService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Task> GetById(int id)
    {
        var task = _taskService.GetById(id);
        if (task == null) return NotFound();
        return task;
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Task task)
    {
        if (id != task.Id) return BadRequest();
        _taskService.Update(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _taskService.Delete(id);
        return NoContent();
    }
}
    