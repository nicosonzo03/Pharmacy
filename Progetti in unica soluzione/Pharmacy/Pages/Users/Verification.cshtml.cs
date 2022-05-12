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
    public class VerificationModel : PageModel
    {
        private readonly AppDbContext _context;
        public VerificationModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string IdUser { get; set; }
        [BindProperty]
        public string Token { get; set; }
        [BindProperty]
        public string ErrorText { get; set; }
        [BindProperty]
        public bool IsFirstOpen { get; set; } = true;
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
                return Page();
            IdUser = id;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            IsFirstOpen = false;
            var emailTokens = _context.EmailTokens.ToList();
            var found = emailTokens.SingleOrDefault(x => x.IdUser == IdUser &&
            x.Token == Token &&
            x.Date > DateTime.Now.AddMinutes(-5));
            if (found == null)
            {
                ErrorText = "Impossible to verify your account:<br />-Wrong 6 chars code<br />-Code is expired (valid for 5 minutes)";
                return Page();
            }
            User User = _context.Users.SingleOrDefault(x => x.Id == IdUser);
            User.IsVerified = true;
            _context.SaveChanges();
            return RedirectToPage("/users/login", new { value = "Now your account is verificated, you can log in and use BestPrices without restrictions" });
        }
    }
}
