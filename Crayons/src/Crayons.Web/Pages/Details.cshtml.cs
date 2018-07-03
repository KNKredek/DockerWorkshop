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
    public class DetailsModel : PageModel
    {
        private IApiService _service;
        public Book Book { get; set; }
        public DetailsModel(IApiService service)
        {
            _service = service;
        }
        public async Task OnGet(int id)
        {
            Book = await _service.Get<Book>($"{ApiConsts.Books}/{id}");
        }
    }
}