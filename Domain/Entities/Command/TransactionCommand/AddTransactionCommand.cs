using MediatR;

namespace Domain.Entities.Command.TransactionCommand
{
    public class AddTransactionCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
    }
}
