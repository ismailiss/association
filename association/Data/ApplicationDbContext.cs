using System;
using System.Collections.Generic;
using System.Text;
using association.Models;
using association.Models.asso_config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace association.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CompteurEau> CompteurEaus { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<association.Models.FacturesGeneree> FacturesGeneree { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
