using Application.Handlers.StudentHandlers;
using LibraryManagementSystem.CQRS.Commands;
using LibraryManagementSystem.Modles;

namespace LibraryManagementSystem.Mapper
{
    public static class StudentMapper
    {
        public static Students MapToModel(AddStudentCommand command)
        {
            return new Students
            {
                Name = command.Name,
                Email = command.Email,
                ContactNumber = command.ContactNumber,
                Department = command.Department
            };
        }
    }
}
