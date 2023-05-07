using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using WebApiDemo.Entities;
using WebApiDemo.Repositories.Abstract;

namespace WebApiDemo.Repositories.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDbContext _dbContext;

        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Student entity)
        {
        }

        public void Delete(Student entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Student Get(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }

        public void Update(Student entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
