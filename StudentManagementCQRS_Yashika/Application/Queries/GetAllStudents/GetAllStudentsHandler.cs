using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS_Yashika.Data;
using StudentManagementCQRS_Yashika.Models;

namespace StudentManagementCQRS_Yashika.Application.Queries.GetAllStudents
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly AppDbContext _context;

        public GetAllStudentsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
