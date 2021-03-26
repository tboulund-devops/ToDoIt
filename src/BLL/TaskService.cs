using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TaskService : IService<Task>
    {
        private IRepository<Task> _repository;
        public TaskService(IRepository<Task> repository)
        {
            _repository = repository ?? throw new ArgumentException("Repository is missing");
        }

        public Task Create(Task entity)
        {
            throw new NotImplementedException();
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
    }
}
