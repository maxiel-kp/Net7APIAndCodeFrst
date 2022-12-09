using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.DALs;
using StudentAPI.Models;
using StudentAPI.DTOs.Requests;
using StudentAPI.Services.Queries;
using MediatR;

namespace MaxCodeFirst.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly PracticeDbContext _dbContext;
        private readonly IStudentService _service;
        private readonly IMediator _mediator;

        public StudentController(PracticeDbContext dbContext, IStudentService service, IMediator mediator)
        {
            _dbContext = dbContext;
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var students = await _dbContext.Students.ToListAsync();
            return Ok(students);
        } 

        [HttpGet]
        [Route("get_student_by_id")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Students student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return Created($"/get_student_by_id?id={student.Id}", student);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Students studentToUpdate)
        {
            _dbContext.Students.Update(studentToUpdate);
            await _dbContext.SaveChangesAsync();
            return Created($"/get_student_by_id?id={studentToUpdate.Id}", studentToUpdate);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var studentToDelete = await _dbContext.Students.FindAsync(id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(studentToDelete);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("get_by_service")]
        public async Task<IActionResult> GetByServiceAsync([FromQuery] GetUserRequest request)
        {
            var users = await _service.SearchAsync(request);
            return Ok(users);
        }

        [HttpGet("get_by_cqrs")]
        public async Task<IActionResult> GetByCQRSAsync([FromQuery] GetUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get_by_cqrs_no_service")]
        public async Task<IActionResult> GetByCQRSNoServiceAsync([FromQuery] GetStudentRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get_by_proc")]
        public async Task<IActionResult> GetByStoreProcAsync([FromQuery] GetStudentProcRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
