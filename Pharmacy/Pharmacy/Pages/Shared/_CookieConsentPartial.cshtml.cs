using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.Features;
using Pharmacy.Data;

namespace BestPrices.Site
{
    public class _CookieConsentPartialModel : PageModel
    {
        public readonly AppDbContext Context;
        public _CookieConsentPartialModel(AppDbContext ctx)
        {
            Context = ctx;
        }
        public void OnGet()
        {

        }
    }
}