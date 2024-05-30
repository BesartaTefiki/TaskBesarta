using TaskManagement2.Models;


namespace TaskManagement2.Repositories.Interfaces
{
    public interface ITasks2Repository
    {


        Task<IEnumerable<Data.Task2>> GetAllTasks();
        Task<Data.Task2> GetTaskById(int id);
        Task AddTask(Models.TaskRequest request);
        Task UpdateTask(Models.TaskRequest request, int id);
        Task DeleteTask(int id);
        Task<IEnumerable<Data.Task2>> GetCompletedTasks();
    }
}
