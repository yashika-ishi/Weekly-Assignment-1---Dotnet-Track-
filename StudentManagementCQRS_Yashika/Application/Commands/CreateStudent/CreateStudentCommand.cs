using MediatR;

namespace StudentManagementCQRS_Yashika.Application.Commands.CreateStudent
{
    public record CreateStudentCommand(string Name, string Email, int Age, string? Course) : IRequest<int>;
}
