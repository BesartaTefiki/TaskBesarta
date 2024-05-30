using Microsoft.EntityFrameworkCore;
using TaskManagement2.Data;
using TaskManagement2.Models;
using TaskManagement2.Repositories.Interfaces;


namespace TaskManagement2.Repositories.Implementations
{
    public class Task2Repository : ITasks2Repository
    {
        private readonly AppDbContext _context;

        public Task2Repository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddTask(Models.TaskRequest request)
        {
            Data.Task2 requestBody = new Data.Task2();

            requestBody.Description = request.Description;
            requestBody.Deadline = request.Deadline;
            requestBody.Name = request.Name;
            requestBody.isCompleted = request.IsCompleted;

            _context.Tasks2.Add(requestBody);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks2.FindAsync(id);

            if (task != null)
            {
                _context.Tasks2.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Data.Task2>> GetAllTasks()
        {
            return await _context.Tasks2.ToListAsync();
        }

        public async Task<IEnumerable<Data.Task2>> GetCompletedTasks()
        {
            return await _context
                .Tasks2
                .Where(element => element.isCompleted == true)
                .ToListAsync();
        }

        public async Task<Data.Task2> GetTaskById(int id)
        {
            var task = await _context.Tasks2.FindAsync(id);

            return task ?? new Data.Task2();
        }

        public async Task UpdateTask(TaskRequest request, int id)
        {
            var task = await _context.Tasks2.FindAsync(id);

            if (task != null)
            {
                task.Description = request.Description;
                task.Deadline = request.Deadline;
                task.Name = request.Name;
                task.isCompleted = request.IsCompleted;

                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
