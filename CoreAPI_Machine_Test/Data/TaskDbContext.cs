using Microsoft.EntityFrameworkCore;
using CoreAPI_Machine_Test.Models;

namespace CoreAPI_Machine_Test.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
