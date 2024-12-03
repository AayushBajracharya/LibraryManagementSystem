using MediatR;

namespace Application.Handlers.StudentHandlers
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Department { get; set; }

        public UpdateStudentCommand(int studentId, string name, string email, string contactNumber, string department)
        {
            StudentId = studentId;
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
            Department = department;
        }
    }
}
