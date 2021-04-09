using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly TodoContext _ctx;
        public TaskRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public Task Create(Task entity)
        {
            var task = _ctx.Tasks.Add(entity);
            _ctx.SaveChanges();
            return task.Entity;
        }

        public Task Delete(Task entity)
        {
            var task = _ctx.Tasks.FirstOrDefault(x => x.Id == entity.Id);
            if (task == null)
            {
                throw new ArgumentException("Task does not exist");
            }

            var deletedTask = _ctx.Tasks.Remove(task);
            _ctx.SaveChanges();
            return deletedTask.Entity;
        }

        public Task Get(int id)
        {
            return _ctx.Tasks
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Task> Read()
        {
            return _ctx.Tasks.AsNoTracking().ToList();
        }

        public Task Update(Task entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return entity;
        }

        public Assignee AssignAssignee(Assignee assignee, Task task)
        {
            task.Assignee = assignee;

            _ctx.Entry(task).State = EntityState.Modified;
            _ctx.SaveChanges();
            return assignee;
        }
    }
}
