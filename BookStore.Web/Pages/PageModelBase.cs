﻿using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Web.Pages
{
    public class PageModelBase : PageModel
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
