using BookStore.Application.Books.Queries.GetBooks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookVm>
    {
        public int BookId { get; set; }

    }
}
