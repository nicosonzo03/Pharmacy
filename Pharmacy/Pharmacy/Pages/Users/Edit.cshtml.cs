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
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        public EditModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string ErrorText { get; set; }
        public User User { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            var u = User.Username;
            Username = u;
            var e = User.Email;
            Email = e;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            if (User.Username != Username)
            {
                if (_context.Users.Select(x => x.Username).Contains(Username))
                {
                    ErrorText = "Username is already taken";
                    return Page();
                }
                User.Username = Username;
            }
            if (User.Email != Email)
            {
                if (_context.Users.Select(x => x.Email).Contains(Email))
                {
                    ErrorText = "Email is already used";
                    return Page();
                }
                User.Email = Email;
            }
            _context.SaveChanges();
            ErrorText = string.Empty;
            return RedirectToPage("/users/Index");
        }
    }
}
