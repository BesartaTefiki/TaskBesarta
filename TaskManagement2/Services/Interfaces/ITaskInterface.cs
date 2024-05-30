using TaskManagement2.DTOs;
using TaskManagement2.Models;

namespace TaskManagement2.Services.Interfaces
{
    public interface ITaskInterface
    {
        Task<IEnumerable<TaskDTO>> GetAllTasks();

        Task<TaskDTO> GetTaskById(int id);

        Task UpdateTask(TaskRequestDTO request, int id);
        Task AddTask(TaskRequestDTO request);

        Task DeleteTask(int id);
        Task<IEnumerable<TaskDTO>> GetCompletedTasks();

        

    }
}
