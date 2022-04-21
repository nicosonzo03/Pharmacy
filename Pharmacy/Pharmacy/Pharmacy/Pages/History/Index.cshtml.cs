using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pharmacy;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.History
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public new User User { get; set; }
        public IList<DiseaseHistoryDTO> Products { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            Products = new List<DiseaseHistoryDTO>();
            if (User == null)
                return Page();

            var userDiseases = _context.UsersDiseases.Where(x => x.IdUser == User.Id).ToList();
            foreach (var p in _context.Diseases)
            {
                var matchingUp = userDiseases.Where(x => x.IdDisease == p.Id).ToList();
                foreach (var up in matchingUp)
                {
                    Products.Add(new DiseaseHistoryDTO()
                    {
                        Date = up.Date,
                        Name = p.Name,
                        Link = "" //link alla pagina details
                    });
                }

            }
            return Page();
        }
    }
}