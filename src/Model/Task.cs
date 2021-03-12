using System;

namespace Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Assignee Assignee { get; set; }
        public bool IsCompleted { get; set; }
    }
}