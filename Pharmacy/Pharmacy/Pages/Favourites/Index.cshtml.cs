using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Favourites
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Disease> Diseases { get; set; }
        public User User { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            User = CookiesManager.GetUserByCookies(HttpContext.Request, _context);
            if (User != null)
            {
                var userDiseases = _context.UsersDiseases.OrderByDescending(x => x.Date).ToList();
                IList<string> IdDiseases = userDiseases.Where(x => x.IdUser == User.Id && x.IsFavourite)
                                                       .ToList()
                                                       .Select(y => y.IdDisease)
                                                       .ToList();
                Diseases = _context.Diseases.Where(x => IdDiseases.Contains(x.Id))
                                            .ToList();
            }

            return Page();
        }

        /// <summary>
        /// Pages/Favourites/Index?handler=SetFavorite&userId={userId}&productId={productId}
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IActionResult OnGetSetFavorite(string userId, string diseaseId)
        {
            var u = _context.UsersDiseases
                .Where(x => x.IdUser == userId && x.IdDisease == diseaseId)
                .FirstOrDefault();

            u.IsFavourite = true;

            _context.SaveChanges();

            return Content("true");
        }

        /// <summary>
        /// Pages/Favourites/Index?handler=DeleteFavorite&userId={userId}&productId={productId}
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="diseaseId"></param>
        /// <returns></returns>
        public IActionResult OnGetDeleteFavorite(string userId, string diseaseId)
        {
            var u = _context.UsersDiseases
                .Where(x => x.IdUser == userId && x.IdDisease == diseaseId)
                .FirstOrDefault();

            u.IsFavourite = false;

            _context.SaveChanges();

            return Content("true");
        }
    }
}