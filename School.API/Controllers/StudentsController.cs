using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.API.Models;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentsController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Ok(_schoolDbContext.Students);
        }

        [HttpPost]
        public async ValueTask<IActionResult> AddStudent(Student student)
        {
            await _schoolDbContext.Students.AddAsync(student);
            await _schoolDbContext.SaveChangesAsync();

            return Ok(student);
        }
    }
}
