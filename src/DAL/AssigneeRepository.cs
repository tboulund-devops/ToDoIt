using Model;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public Assignee Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Assignee> Read()
        {
            throw new NotImplementedException();
        }

        public Assignee Update(Assignee entity)
        {
            throw new NotImplementedException();
        }
    }
}
