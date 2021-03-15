using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignee> Assignees { get; set; }
    }
}