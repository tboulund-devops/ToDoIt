using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AssigneeService : IService<Assignee>
    {
        private IRepository<Assignee> _repository;
        public AssigneeService(IRepository<Assignee> repository)
        {
            _repository = repository ?? throw new ArgumentException("Repository is missing");
        }
        public Assignee Create(Assignee entity)
        {
            throw new NotImplementedException();
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
