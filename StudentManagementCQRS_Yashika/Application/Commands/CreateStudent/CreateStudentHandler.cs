using MediatR;
using StudentManagementCQRS_Yashika.Data;
using StudentManagementCQRS_Yashika.Models;

namespace StudentManagementCQRS_Yashika.Application.Commands.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Email = request.Email,
                Age = request.Age,
                Course = request.Course
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return student.Id;
        }
    }
}
