using BookStore.Application.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Web.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public IList<BookVm> Book { get; set; }

        public async void OnGet()
        {
            var books = await Mediator.Send(new GetBookQuery());
            Book = books.ToList();
        }
    }
}
