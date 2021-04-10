using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IRepository<T>
    {
        public T Create(T entity);
        public List<T> Read();
        public T Update(T entity);
        public T Delete(T entity);
        public T Get(int id);
        public Assignee AssignAssignee(Assignee assignee, Task task);
    }
}
