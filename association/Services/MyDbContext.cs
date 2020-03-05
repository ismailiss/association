using association.Models;
using association.Models.asso_config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace association.Services
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {

     
        public DbSet<Client> Clients { get; set; }
        public DbSet<CompteurEau> CompteurEaus { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<Douar> Douars { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //ISMAOUI\SQLEXPRESS


            //optionsBuilder.UseSqlServer("Data Source=SQL6006.site4now.net;Initial Catalog=DB_A46566_ismail12345;User Id=DB_A46566_ismail12345_admin;Password=OkeoPXQO1;");

            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=asso1;Trusted_Connection=True;");
        }


        //public DbSet<association.Models.Tarif> Tarifs { get; set; }

        public DbSet<association.Models.FacturesGeneree> FacturesGeneree { get; set; }
    }
}
