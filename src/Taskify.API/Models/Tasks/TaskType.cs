using System.Collections.Generic;

namespace Taskify.API.Models.Tasks
{
    public class TaskType
    {
        public int Id {get;set;}
        public string Type {get;set;}
        public ICollection<Task> Tasks {get;set;}
    }
}