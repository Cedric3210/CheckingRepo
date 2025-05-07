using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Consultation.Infrastructure.Migrations;
using FlutterAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController: ControllerBase
    {
        private readonly AppDbContext _context;
        public ConsultationController(AppDbContext context)
        {
            _context = context;
        }

        //Screen 3.1 API
        [HttpPost]
        public IActionResult RequestConsulation([FromBody] ConsulatationViewModel ConsultationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //query para sa student
            var student = _context.Students.FirstOrDefault(s => s.StudentName 
            == ConsultationRequest.StudentName);

            //query para sa faculty
            var faculty = _context.Faculty.FirstOrDefault(f => f.FacultyName 
            == ConsultationRequest.FacultyName);

            if (student == null)
                return NotFound("Student not found");

            if(faculty == null)
                return NotFound("Faculty not found");


            var consultation = new ConsultationRequest
            {
                StudentID = student.StudentID.ToString(),
                FacultyID = faculty.FacultyID,
                SubjectCode = ConsultationRequest.CourseCode,
                DateSchedule = ConsultationRequest.DateOfConsultation,
                StartedTime = ConsultationRequest.TimeStarted,
                EndedTime = ConsultationRequest.TimeEnded
            };


            _context.ConsultationRequest.Add(consultation); 
            _context.SaveChanges();

            _context.ActionLog.Add(new ActionLog
            {
                Description = "Consultation Request",
                Date = DateTime.Now,
                Time = TimeOnly.FromDateTime(DateTime.Now)
            });
            _context.SaveChanges();

            return Ok(new { message = "Action Successful" });
        }

        //Screen 4 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultationRequest>>> ShowConsultation(int studentId)
        {
            var result = await _context.ConsultationRequest
            .Include(s => s.Student)
             .Include(s => s.Faculty)
             .Where(s => s.StudentID == studentId.ToString())
               .ToListAsync();
            return Ok(result);
        }
    }
}
