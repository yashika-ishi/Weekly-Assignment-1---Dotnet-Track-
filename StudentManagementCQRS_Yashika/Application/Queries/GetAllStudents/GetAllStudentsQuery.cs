using MediatR;
using StudentManagementCQRS_Yashika.Models;

namespace StudentManagementCQRS_Yashika.Application.Queries.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
}
