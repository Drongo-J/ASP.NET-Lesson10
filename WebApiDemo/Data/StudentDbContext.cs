using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;

namespace WebApiDemo.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
