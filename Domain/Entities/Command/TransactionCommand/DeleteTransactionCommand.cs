using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Entities.Command.TransactionCommand
{
    public class DeleteTransactionCommand : IRequest<bool>
    {
        public int TransactionId { get; }

        public DeleteTransactionCommand(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
