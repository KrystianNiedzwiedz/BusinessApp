using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Queries.GetBooks;
using BookStore.Web.Pages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Web.Pages
{
    public class CreateModel : PageModelBase
    {
        [BindProperty]
        public BookVm Book { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            await Mediator.Send(new CreateBookCommand { Name = Book.Name, Description = Book.Description, Author = Book.Author });
            return RedirectToPage("./Index");
        }
    }
}
