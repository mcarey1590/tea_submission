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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _repo;

        public StudentsController(IStudentsRepository repo)
        {
            _repo = repo;
        }

        // GET: Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return Ok(await _repo.GetAll());
        }

        // GET: Students/5/transcript
        [HttpGet("{id}/transcript")]
        public async Task<ActionResult<Transcript>> GetStudentTranscript(int id)
        {
            var studentTranscript = await _repo.GetTranscript(id);

            if (studentTranscript == null)
            {
                return NotFound();
            }

            return studentTranscript;
        }
    }
}
