using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Entities.Command.TransactionCommand
{
    public class UpdateTransactionCommand : IRequest<bool>
    {
        public int TransactionId { get; set; }
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
    }
}
