using MediatR;

namespace Domain.Entities.Command.BookCommand
{
    public class AddBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }

        public AddBookCommand(string title, int authorId, string genre, string isbn, int quantity)
        {
            Title = title;
            AuthorId = authorId;
            Genre = genre;
            ISBN = isbn;
            Quantity = quantity;
        }
    }

}
