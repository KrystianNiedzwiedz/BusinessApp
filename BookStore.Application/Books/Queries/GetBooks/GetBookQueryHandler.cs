using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Repository;

namespace BookStore.Application.Books.Queries.GetBooks
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookVm>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper) {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookVm>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var books =  await _bookRepository.GetAllBooksAsync();
            var bookList = _mapper.Map<List<BookVm>>(books);
            return bookList;
        }
    }
}
