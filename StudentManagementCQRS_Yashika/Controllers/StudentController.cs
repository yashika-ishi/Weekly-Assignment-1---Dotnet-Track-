using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagementCQRS_Yashika.Application.Commands.CreateStudent;
using StudentManagementCQRS_Yashika.Application.Commands.UpdateStudent;
using StudentManagementCQRS_Yashika.Application.Commands.DeleteStudent;
using StudentManagementCQRS_Yashika.Application.Queries.GetAllStudents;

namespace StudentManagementCQRS_Yashika.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/students
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { StudentId = id });
        }

        // PUT api/students/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch between route and body.");

            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE api/students/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }

        // GET api/students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }
    }
}
