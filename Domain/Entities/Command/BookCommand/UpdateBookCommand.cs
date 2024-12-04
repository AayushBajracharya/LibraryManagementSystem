using MediatR;

namespace Domain.Entities.Command.BookCommand
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }

        public UpdateBookCommand(int bookId, string title, int authorId, string genre, string isbn, int quantity)
        {
            BookId = bookId;
            Title = title;
            AuthorId = authorId;
            Genre = genre;
            ISBN = isbn;
            Quantity = quantity;
        }
    }

}
