using AutoMapper;
using TaskManagement2.DTOs;
using TaskManagement2.Models;
using TaskManagement2.Repositories.Implementations;
using TaskManagement2.Repositories.Interfaces;
using TaskManagement2.Services.Interfaces;
namespace TaskManagement2.Services.Implementations

{
    public class TaskService : ITaskInterface
    {
        private readonly ITasks2Repository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITasks2Repository taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task AddTask(TaskRequestDTO request)
        {    // metoden 
            var model = _mapper.Map<TaskRequest>(request);  // Map DTO to Model
            await _taskRepository.AddTask(model);
        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }


        public async Task<IEnumerable<TaskDTO>> GetCompletedTasks()
        {
            var completedTasks = await _taskRepository.GetCompletedTasks();

            var response = completedTasks?.Select(element =>
            {
                TaskDTO taskDto = new TaskDTO();

                return _mapper.Map(element, taskDto);
            });

            return response;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {

           
            var tasks = await _taskRepository.GetAllTasks();

            var response = tasks?.Select(element =>
            {
                TaskDTO taskDto = new TaskDTO();

                return _mapper.Map(element, taskDto);
            });

            return response;   
        }

        public async Task<TaskDTO> GetTaskById(int id)
        {
            var task = await _taskRepository.GetTaskById(id);

            TaskDTO taskDto = new TaskDTO();

            //taskDto.Description = task.Description;
            //taskDto.Name = task.Name;
            //taskDto.Id = task.Id;
            //taskDto.IsCompleted = task.IsCompleted;
            //taskDto.Username = task.Username;

            var response = _mapper.Map(task, taskDto);

            return response;
        }

        public async System.Threading.Tasks.Task UpdateTask(TaskRequestDTO request, int id)
        {     //ket e kam mar prej chatgpt
            var model = _mapper.Map<TaskRequest>(request);  // Map DTO to Model
            await _taskRepository.UpdateTask(model, id);
        }
    }
}
