using System;

namespace Taskify.API.DTOs.Tasks
{
    public class TaskMowLawnForCreationDto
    {
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BeginsAt { get; set; }
        public string AdditionalInformation { get; set; }
        public int? BackyardWidth { get; set; }
        public int? BackyardLength { get; set; }
        public int? FrontyardWidth { get; set; }
        public int? FrontyardLength { get; set; }
        public int? LeftSideWidth { get; set; }
        public int? LeftSideLength { get; set; }
        public int? RightSideWidth { get; set; }
        public int? RightSideLength { get; set; }
        public bool IDoHaveSawingMachine { get; set; }
        public bool IDoNotHaveSawingMachine { get; set; }

        public TaskMowLawnForCreationDto()
        {
            CreatedAt = DateTime.Now;
        }
    }
}