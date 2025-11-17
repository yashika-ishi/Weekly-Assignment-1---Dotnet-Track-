using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS_Yashika.Data;

namespace StudentManagementCQRS_Yashika.Application.Commands.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (student is null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
