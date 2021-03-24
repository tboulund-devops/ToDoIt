using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;


namespace DAL.Interfaces
{
    public interface ITaskRepository
    {
        Task CreateTask(Task task);
        Task ReadTaskById(int id);
        IEnumerable<Task> ReadAllTasks();
        Task UpdateTask(int id, DateTime dueDate);
        Task DeleteTask(int id);
    }
}
