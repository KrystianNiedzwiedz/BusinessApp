using BookStore.Application.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Application.Books.Queries.GetBooks;

namespace BookStore.Web.Pages
{
    public class DetailsModel : PageModelBase
    {
        [BindProperty]
        public BookVm Book { get; set; } = default!;
        public async Task<IActionResult> OnGet(int id)
        {
            var book = await Mediator.Send(new GetBookByIdQuery() { BookId = id });
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
