using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
            _apiManager = new ApiManager();
        }
        [BindProperty]
        public string SearchText { get; set; }
        [BindProperty]
        public IList<Disease> Diseases { get; set; }

        [BindProperty]
        public string ErrorText { get; set; }
        public User User { get; set; }
        ApiManager _apiManager { get; set; }

        public string pezzo1 { get; set; }

        public string pezzo2 { get; set; }


        public IList<string> sint = new List<string>();

        public IActionResult OnGet(string text)
        {
            string[] arraysint = text.Split(',');
            sint = arraysint.ToList();
            SearchText = text;
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string text)
        {
            string[] arraysint = text.Split(',');
            sint = arraysint.ToList();
            Diseases = _apiManager.GetDiseases(text);
            ErrorText = string.Empty;
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            foreach (var p in Diseases)
            {
                var sameDisease = new Disease();
                sameDisease = _context.Diseases.Where(x => x.Name == p.Name).SingleOrDefault();
                if (sameDisease == null)
                {
                    _context.Diseases.Add(p);
                    if (User != null)
                    {
                        var newUserDisease = new UserDisease()
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdDisease = p.Id,
                            IdUser = User.Id,
                            Date = DateTime.Now
                        };
                        _context.UsersDiseases.Add(newUserDisease);
                    }
                }
                else
                {
                    if (User != null)
                    {
                        var newUserDisease = new UserDisease()
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdDisease = sameDisease.Id,
                            IdUser = User.Id,
                            Date = DateTime.Now
                        };
                        _context.UsersDiseases.Add(newUserDisease);
                    }
                }

                _context.SaveChanges();
            }
            if (Diseases.Count() == 0)
                ErrorText = $"No disease found searching: '{text}'";
            return Page();
        }
    }
}
