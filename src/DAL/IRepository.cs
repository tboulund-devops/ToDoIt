﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        public T Create(T entity);
        public List<T> Read();
        public T Update(T entity);
        public T Delete(T entity);
        public T Get(int id);
    }
}
