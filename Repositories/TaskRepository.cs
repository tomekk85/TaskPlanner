using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Models;

namespace TaskPlanner.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskPlannerContext _context;
        public TaskRepository(TaskPlannerContext context)
        {
            _context = context;
        }
        public TaskModel Get(int taskId) => _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);

        public IQueryable<TaskModel> GetAllActive() => _context.Tasks.Where(t => t.Done == false);

        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);

            _context.SaveChanges();
        }
        
        public void Update(int taskId, TaskModel task)
        {
            TaskModel taskToUpdate = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if(taskToUpdate!= null)
            {
                taskToUpdate.Name = task.Name;
                taskToUpdate.Description = task.Description;
                taskToUpdate.Done = task.Done;

                _context.SaveChanges();
            }
            
        }

        public void Delete(int taskId)
        {
            TaskModel taskToDelete = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if(taskToDelete!= null)
            {
                _context.Tasks.Remove(taskToDelete);

                _context.SaveChanges();
            }

        }
    }
}
