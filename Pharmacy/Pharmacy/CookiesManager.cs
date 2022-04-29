using Microsoft.AspNetCore.Http;
using Pharmacy.Data;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy
{
    public static class CookiesManager
    {
        public static string UserIdKey = "UserId";
        public static CookieOptions CookieOptions = new CookieOptions()
        {
            Expires = DateTime.Now.AddDays(30),
            IsEssential = true,
            Secure = true
        };
        public static User GetUserByCookies(HttpRequest request, AppDbContext context)
        {
            User user;
            var cookies = request.Cookies;
            var userId = cookies[UserIdKey];
            try
            {
                user = context.Users.SingleOrDefault(x => x.Id == userId);
            }
            catch
            {
                user = null;
            }
            return user;
        }
    }
}
