﻿using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    class AssigneeRepository : IRepository<Assignee>
    {
        private readonly TodoContext _ctx;

        public AssigneeRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public Assignee Create(Assignee entity)
        {
            var assignee = _ctx.Assignees.Add(entity);
            _ctx.SaveChanges();
            return assignee.Entity;
        }

        public Assignee Delete(Assignee entity)
        {
            var assignee = _ctx.Assignees.FirstOrDefault(x => x.Id == entity.Id);
            if (assignee == null)
            {
                throw new ArgumentException("Assignee does not exist");
            }
            var deletedAssignee = _ctx.Assignees.Remove(assignee);
            _ctx.SaveChanges();
            return deletedAssignee.Entity;
        }

        public Assignee Get(int id)
        {
            return _ctx.Assignees
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Task> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public List<Assignee> Read()
        {
            return _ctx.Assignees.AsNoTracking().ToList();
        }

        public Assignee Update(Assignee entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return entity;
        }
    }
}
