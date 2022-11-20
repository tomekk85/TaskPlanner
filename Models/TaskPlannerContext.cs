using Microsoft.EntityFrameworkCore;

namespace TaskPlanner.Models
{
    public class TaskPlannerContext : DbContext
    {
        public TaskPlannerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
