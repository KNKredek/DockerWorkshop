﻿using System;
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
    public class IndexModel : PageModel
    {
        private IApiService _service;
        public IList<Book> Books { get; set; }
        public IndexModel(IApiService service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {
            Books = await _service.Get<IList<Book>>(ApiConsts.Books);
        }
    }
}
