using System.Collections.Generic;
using System.Linq;

public class TaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Task task) => _context.Tasks.Add(task);
    public List<Task> GetAll() => _context.Tasks.ToList();
    public Task GetById(int id) => _context.Tasks.Find(id);
    public void Update(Task task) => _context.Tasks.Update(task);
    public void Delete(Task task) => _context.Tasks.Remove(task);
    public void SaveChanges() => _context.SaveChanges();
}
