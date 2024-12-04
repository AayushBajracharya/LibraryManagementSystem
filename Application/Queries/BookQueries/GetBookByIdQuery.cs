using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Modles;
using MediatR;

namespace Application.Queries.BookQueries
{
    public class GetBookByIdQuery : IRequest<Books>
    {
        public int BookId { get; set; }

        public GetBookByIdQuery(int bookId)
        {
            BookId = bookId;
        }
    }

}
