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
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Disease malattiacercata { get; set; }

        public string pezzo1 { get; set; }

        public string pezzo2 { get; set; }
        public IActionResult OnGet(string ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.malattiacercata = _context.Diseases.Where(m => m.Id == id).FirstOrDefault();

            if (malattiacercata == null)
            {
                return NotFound();
            }
            else
            {
                malattiacercata.Description = malattiacercata.Description.Replace("\u2019", "'").Replace("\u0027", "'").Replace("\u201C", "\"").Replace("\u201D", "\"");
                pezzo1 = malattiacercata.Description.Split("\n\n")[0];
                pezzo2 = malattiacercata.Description.Split("\n\n")[1];
                return Page();
            }
        }
    }
}
