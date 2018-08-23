using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskify.API.Data.Tasks;
using Taskify.API.DTOs.Tasks;

namespace Taskify.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    public class HelperController : Controller
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public HelperController(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("tasktypes/list")]
        public async Task<IActionResult> ListTaskTypes()
        {
            var tasksTypes = await _repository.GetTaskTypes();

            var tasksTypesToReturn = _mapper.Map<IEnumerable<TaskTypeToReturnDto>>(tasksTypes);

            return Ok(tasksTypesToReturn);
        }
    }
}