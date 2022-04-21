using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<UserDisease> UsersDiseases { get; set; }

        public DbSet<DiseaseMedicine> DiseasesMedicines { get; set; }

        public DbSet<EmailToken> EmailTokens { get; set; }
    }
}
