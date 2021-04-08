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
            if (_repository.Get(entity.Id) != null)
            {
                throw new InvalidOperationException("Task already exists");
            }
            ValidationCheck(entity);
            return _repository.Create(entity);
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

        private void ValidationCheck(Task entity)
        {
            if (String.IsNullOrEmpty(entity.Description))
            {
                throw new ArgumentException("Invalid Task");
            }
            if (entity.Assignee == null)
            {
                throw new ArgumentException("Invalid Task");
            }
            if (entity.DueDate == null)
            {
                throw new ArgumentException("Invalid Task");
            }
        }
    }
}
