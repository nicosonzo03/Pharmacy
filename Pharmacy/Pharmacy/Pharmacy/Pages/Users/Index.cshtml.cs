using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public new User User { get; set; }
        public int FavCount { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            if (User != null)
                FavCount = _context.UsersDiseases.Where(x => x.IdUser == User.Id && x.IsFavourite)
                                             .ToList()
                                             .Count;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var cookies = Response.Cookies;
            var index = CookiesManager.UserIdKey;
            var options = CookiesManager.CookieOptions;
            cookies.Append(index, string.Empty, options);
            return Page();
        }
    }
}
