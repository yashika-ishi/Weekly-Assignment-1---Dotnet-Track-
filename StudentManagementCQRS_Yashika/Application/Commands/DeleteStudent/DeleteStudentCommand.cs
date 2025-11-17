using MediatR;

namespace StudentManagementCQRS_Yashika.Application.Commands.DeleteStudent
{
    public record DeleteStudentCommand(int Id) : IRequest<bool>;
}
