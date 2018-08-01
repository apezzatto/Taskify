using System;

namespace Taskify.API.Models.Tasks
{
    public class MowLawn
    {
        public Guid Id {get; set;}
        public int? BackyardWidth {get;set;}
        public int? BackyardLength {get;set;}
        public int? FrontyardWidth {get;set;}
        public int? FrontyardLength {get;set;}
        public int? LeftSideWidth {get;set;}
        public int? LeftSideLength {get;set;}
        public int? RightSideWidth {get;set;}
        public int? RightSideLength {get;set;}
        public bool IDoHaveSawingMachine {get;set;}
        public bool IDoNotHaveSawingMachine {get;set;}
        public Task Task {get;set;}
        public Guid TaskId {get;set;}

        public MowLawn()
        {
            Id = Guid.NewGuid();
        }
    }
}