using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Symptoms
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string SearchText { get; set; }

        [BindProperty]
        public string ResultText { get; set; }
        
        public static IList<string> Symptoms = new List<string>();

        
        public IList<string> sint = new List<string>();

        [BindProperty]
        public string ErrorText { get; set; }
        public User User { get; set; }

        
        public IList<Symptom> elencosintomi = new List<Symptom>();

        public IActionResult OnGet()
        {
            Symptoms.Clear();
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            foreach (var item in _context.elencosintomi)
            {
                elencosintomi.Add(item);
            }
            
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ErrorText = string.Empty;
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);

            elencosintomi = _context.elencosintomi.ToList();

            Symptoms.Add(SearchText);

            foreach(var item in Symptoms)
            {
                ResultText = ResultText + item + ",";

                var sintomocercato = elencosintomi.Where(x => x.sintomo == item).FirstOrDefault();
                elencosintomi.Remove(sintomocercato);
            }
            ResultText = ResultText.Substring(0, ResultText.Length - 1);

            sint = Symptoms.ToList();

            return Page();
        }
    }
}
