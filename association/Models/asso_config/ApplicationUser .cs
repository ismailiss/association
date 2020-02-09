using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models.asso_config
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(30)]
        public string Nom { get; set; }
  
        [StringLength(30)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        public int? AssociationID { get; set; }
        [ForeignKey("AssociationID")]
        public virtual Association Association { get; set; }
    }
}
