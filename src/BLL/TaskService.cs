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

        public List<Task> Search(string searchText)
        {
            if (searchText == null)
            {
                return Read();
            }
            
            return _repository.Search(searchText);
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
            if (_repository.Get(entity.Id) != null)
            {
                return _repository.Delete(entity);
            }
            throw new InvalidOperationException("Task not found");
        }

        public Task Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Task> Read()
        {
            return _repository.Read();
        }

        public Task Update(Task entity)
        {
            ValidationCheck(entity);
            return _repository.Update(entity);
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
