using System.Collections.Generic;

public class TaskService
{
    private readonly TaskRepository _repository;

    public TaskService(TaskRepository repository)
    {
        _repository = repository;
    }

    public void Create(Task task)
    {
        _repository.Add(task);
        _repository.SaveChanges();
    }

    public List<Task> GetAll() => _repository.GetAll();
    public Task GetById(int id) => _repository.GetById(id);
    public void Update(Task task)
    {
        _repository.Update(task);
        _repository.SaveChanges();
    }

    public void Delete(int id)
    {
        var task = _repository.GetById(id);
        if (task != null)
        {
            _repository.Delete(task);
            _repository.SaveChanges();
        }
    }
}
