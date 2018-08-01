using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskify.API.Data.Tasks;
using Taskify.API.DTOs.Tasks;
using Taskify.API.Helpers;
using Taskify.API.Models.Tasks;

namespace Taskify.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(int userId, 
            [FromBody] TaskMowLawnForCreationDto taskForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            if (userId != taskForCreationDto.ClientId)
                return Unauthorized();

            var task = _mapper.Map<Taskify.API.Models.Tasks.Task>(taskForCreationDto);
            var mowLawn = _mapper.Map<MowLawn>(taskForCreationDto);

            mowLawn.TaskId = task.Id;

            _repository.Add(task);
            _repository.Add(mowLawn);

            if (await _repository.SaveAll())
                return Ok();

            throw new Exception("Fail to create the task.");
        }
    }
}