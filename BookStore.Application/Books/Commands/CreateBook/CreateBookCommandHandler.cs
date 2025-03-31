using AutoMapper;
using BookStore.Application.Books.Queries.GetBooks;
using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookVm>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookVm> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEnity = new Book()
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author,
            };
            var Result = await _bookRepository.CreateAsync(bookEnity);
            return _mapper.Map<BookVm>(Result);
        }
    }
}
