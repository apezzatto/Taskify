using System;
using System.Collections.Generic;

namespace Taskify.API.Models.Tasks
{
    public class Task
    {
        public Guid Id {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime BeginsAt {get;set;}
        public DateTime? EndedAt {get;set;}
        public string AdditionalInformation {get; set;}
        public User Client {get;set;}
        public int ClientId {get;set;}
        public User Worker {get; set;}
        public int? WorkerId {get;set;}
        public ICollection<MowLawn> MowLawnTasks { get; set; }

        public Task()
        {
            Id = Guid.NewGuid();
        }
    }
}