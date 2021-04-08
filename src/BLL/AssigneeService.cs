﻿using DAL;
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
            if (_repository.Get(entity.Id) != null)
            {
                throw new InvalidOperationException("Assignee already exists");
            }
            ValidationCheck(entity);
            return _repository.Create(entity);
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

        private void ValidationCheck(Assignee entity)
        {
            if (String.IsNullOrEmpty(entity.Name))
            {
                throw new ArgumentException("Invalid Assignee");
            }
        }
    }
}