using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crayons.Web.Consts;
using Crayons.Web.Models;
using Crayons.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Crayons.Web.Pages
{
    public class AddModel : PageModel
    {
        private IApiService _service;
        [BindProperty]
        public Book Book { get; set; }
        public AddModel(IApiService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Book = new Book()
            {
                Author = new Author(),
                CreationDate = DateTime.Now
            };
        }
        public async Task<IActionResult> OnPostAsync ()
        {
            await _service.Post<Book> (Book, ApiConsts.Books);

            return RedirectToPage ("/Index");
        }
    }
}