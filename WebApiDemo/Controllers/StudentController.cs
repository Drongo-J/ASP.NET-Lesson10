using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Dtos;
using WebApiDemo.Entities;
using WebApiDemo.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentDto> Get()
        {
            var items = _studentService.GetAll();
            var dataToReturn = items.Select(a =>
            {
                return new StudentDto()
                {
                    Id = a.Id,
                    Age = a.Age,
                    Fullname = a.Fullname,
                    Score = a.Score,
                    SeriaNo = a.SeriaNo
                };
            });
            return dataToReturn;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentDto Get(int id)
        {
            var item = _studentService.Get(id);
            var dataToReturn = new StudentDto()
            {
                Id = item.Id,
                Age = item.Age,
                Fullname = item.Fullname,
                Score = item.Score,
                SeriaNo = item.SeriaNo
            };
            return dataToReturn;
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentDto value)
        {
            try
            {
                var obj = new Student()
                {
                    Age = value.Age,
                    Fullname = value.Fullname,
                    Score = value.Score,
                    SeriaNo = value.SeriaNo
                };
                _studentService.Add(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentDto value)
        {
            try
            {
                var obj = new Student()
                {
                    Id = id,
                    Age = value.Age,
                    Fullname = value.Fullname,
                    Score = value.Score,
                    SeriaNo = value.SeriaNo
                };
                _studentService.Update(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
