using association.Models.asso_config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class Association
    {
        [Key]
        public int AssociationID { get; set; }
        [StringLength(30)]
        public string Nom { get; set; }
        
        [StringLength(255)]
        public string Adresse { get; set; }

        [StringLength(15)]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<FacturesGeneree> FacturesGenerees { get; set; }


    }
}
