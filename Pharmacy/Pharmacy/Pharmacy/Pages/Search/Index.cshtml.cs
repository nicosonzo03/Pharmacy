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
        public List<string> Symptoms { get; set; }

        [BindProperty]
        public string ErrorText { get; set; }
        public User User { get; set; }
        ApiManager _apiManager { get; set; }

        public IActionResult OnGet()
        {
            Symptoms = _apiManager.GetSymptoms();
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            //Diseases = _apiManager.GetProducts(SearchText);
            ErrorText = string.Empty;
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            foreach (var p in Diseases)
            {
                var sameDisease = _context.Diseases.Where(x => x.Name == p.Name).SingleOrDefault();
                if (sameDisease == null)
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
                _context.SaveChanges();
            }
            if (Diseases.Count() == 0)
                ErrorText = $"No disease found searching: '{SearchText}'";
            return Page();
        }
    }
}
