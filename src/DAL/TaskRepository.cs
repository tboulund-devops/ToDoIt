using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> Read()
        {
            throw new NotImplementedException();
        }

        public Task Update(Task entity)
        {
            throw new NotImplementedException();
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
