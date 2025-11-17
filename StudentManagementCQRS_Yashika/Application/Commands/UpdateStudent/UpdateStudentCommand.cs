using MediatR;
using StudentManagementCQRS_Yashika.Models;

namespace StudentManagementCQRS_Yashika.Application.Commands.UpdateStudent
{
    // Contains Id and fields to update
    public record UpdateStudentCommand(int Id, string Name, string Email, int Age, string? Course) : IRequest<bool>;
}
