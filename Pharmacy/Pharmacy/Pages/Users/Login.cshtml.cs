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
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        public LoginModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string UsernameEmail { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ErrorText { get; set; }
        public string Value { get; set; }
        public User User { get; set; }
        public async Task<IActionResult> OnGetAsync(string? value)
        {
            if (value != null)
                Value = value;
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string encPassword = PasswordManager.EncodePasswordToBase64(Password);
            User user = _context.Users.SingleOrDefault(x => (x.Username == UsernameEmail || x.Email == UsernameEmail) &&
            x.Password == encPassword &&
            x.IsVerified);
            if (user == null)
            {
                ErrorText = "Wrong username/email or password, or user not verified yet";
                return Page();
            }
            var cookies = HttpContext.Response.Cookies;
            var options = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30),
                IsEssential = true,
                Secure = true
            };
            var key = CookiesManager.UserIdKey;
            cookies.Delete(key);
            cookies.Append(key, user.Id, options);
            return RedirectToPage("/users/Index");
        }
    }
}
