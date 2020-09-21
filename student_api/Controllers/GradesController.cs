using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using student_api.Repositories;
using student_api.Models;
using student_api.ViewModels;

namespace student_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradesRepository _repo;
        private readonly IStudentsRepository _studentsRepo;
        private readonly ICoursesRepository _coursesRepo;

        public GradesController(IGradesRepository repo, IStudentsRepository studentsRepo, ICoursesRepository coursesRepo)
        {
            _repo = repo;
            _studentsRepo = studentsRepo;
            _coursesRepo = coursesRepo;
        }


        // POST: grades
        [HttpPost("")]
        
        public ActionResult<Transcript> AddGrade(StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_studentsRepo.Exists(studentGrade.StudentID))
            {
                return NotFound("Student not found");
            }

            if (!_coursesRepo.Exists(studentGrade.CourseID))
            {
                return NotFound("Course not found");
            }


            var addedGrade = _repo.AddGrade(studentGrade);
            if(addedGrade == null)
            {
                return BadRequest("Failed to add grade. Please check request values and try again"); // ideally we would let the consumer know exactly why the request failed
            }
            return Created("Grade was added", addedGrade);
        }
    }
}
