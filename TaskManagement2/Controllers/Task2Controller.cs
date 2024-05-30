using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks.Sources;
using TaskManagement2.Data;
using TaskManagement2.DTOs;
using TaskManagement2.Models;
using TaskManagement2.Repositories.Interfaces;
using TaskManagement2.Services.Implementations;
using TaskManagement2.Services.Interfaces;

namespace TaskManagement2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Task2Controller : ControllerBase
    {//injection
        private readonly ITaskInterface _taskService;
       private readonly IMemoryCache _memoryCache;
        public Task2Controller(ITaskInterface taskService,IMemoryCache memoryCache)
        {
            _taskService = taskService;    //ckjo me _ osht emri konstruktorit
            _memoryCache = memoryCache;
        }


        //_tasksRepository  emri i kontrollerit


        [HttpGet]
       // [Authorize]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks()
        {

            if (_memoryCache.TryGetValue("myData", out IEnumerable<TaskDTO> myData))
            {
                return Ok(myData);
            }
            var tasks = await _taskService.GetAllTasks();
            _memoryCache.Set("myData",Response, TimeSpan.FromMinutes(5));
            return Ok (tasks);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(TaskRequestDTO request)
        {
            await _taskService.AddTask(request);
            return Ok();
        }

        [HttpDelete("/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }

        [HttpGet("/completed")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetCompletedTasks()
        {
            var response = await _taskService.GetCompletedTasks();
            return Ok(response);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<TaskDTO>> GetTaskById(int id)
        {


            if (_memoryCache.TryGetValue("gettaskbyid", out TaskDTO myData))
            {
                return Ok(myData);
            }
            _memoryCache.Set("myData", Response, TimeSpan.FromMinutes(2));
            var response = await _taskService.GetTaskById(id);
            return Ok(response);
        }

        [HttpPut("/{id}")]
        public async Task<ActionResult> UpdateTask(TaskRequestDTO request, int id)
        {
            await _taskService.UpdateTask(request, id);
            return Ok();
        }
    }
}
