using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS_Yashika.Data;

namespace StudentManagementCQRS_Yashika.Application.Commands.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (student is null) return false;

            student.Name = request.Name;
            student.Email = request.Email;
            student.Age = request.Age;
            student.Course = request.Course;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
