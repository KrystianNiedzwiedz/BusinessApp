using AutoMapper;
using BookStore.Application.Books.Queries.GetBooks;
using BookStore.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookVm>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookVm> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _bookRepository.GetByIdAsync(request.BookId);
            return _mapper.Map<BookVm>(blog);
        }
    }
}
