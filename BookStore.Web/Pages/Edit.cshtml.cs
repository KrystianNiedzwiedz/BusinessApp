using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Books.Queries.GetBookById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Application.Books.Queries.GetBooks;

namespace BookStore.Web.Pages
{
    public class EditModel : PageModelBase
    {
        [BindProperty]
        public BookVm Book { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            var book=  await Mediator.Send(new GetBookByIdQuery() { BookId= id });
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await Mediator.Send(new UpdateBookCommand
            {
                Id = Book.Id,
                Author = Book.Author,
                Description = Book.Description,
                Name = Book.Name,
            });
            return RedirectToPage("./Index");
        }

    }
}
