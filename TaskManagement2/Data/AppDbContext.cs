using Microsoft.EntityFrameworkCore;

namespace TaskManagement2.Data
{
    public class AppDbContext : DbContext
        
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Task2> Tasks2 { get; set; }
    }
    

}
