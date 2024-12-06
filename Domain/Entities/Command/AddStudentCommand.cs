using MediatR;

namespace LibraryManagementSystem.CQRS.Commands
{
    public class AddStudentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Department { get; set; } 

        public AddStudentCommand(string name, string email, string contactNumber, string department)
        {
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
            Department = department;
        }
    }
}
