using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Email
{
    public class Components
    {
        public Components(string user, string token)
        {
            User = user;
            Token = token;
        }
        public string NameSender { get => "Pharmacy Developer"; }
        public string Sender { get => "pharmacydeveloper"; }
        public string Subject { get => "Email verification"; }
        public string User { get; set; }
        public string Token { get; set; }
        public string Body { get => $"Hi {User}, welcome on Pharmacy!\nInsert this code into the verification page to verify your identity:\n{Token}"; }
    }
}
