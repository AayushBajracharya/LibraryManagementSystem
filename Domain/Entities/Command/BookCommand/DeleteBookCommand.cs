
using MediatR;

namespace Domain.Entities.Command.BookCommand
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public int BookId { get; set; }

        public DeleteBookCommand(int bookId)
        {
            BookId = bookId;
        }
    }

}
