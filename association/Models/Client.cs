using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [StringLength(30)]
        public string Nom { get; set; }
        [StringLength(30)]
        [Display(Name = "Prénom")]

        public string Prenom { get; set; }
        [Display(Name = "Citoyen")]
        public string NomPrenom {
            get {
                return Nom + " " + Prenom; }
        }
        [StringLength(10)]
        public string CIN { get; set; }
        [StringLength(255)]
        public string Adresse { get; set; }
        [StringLength(15)]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }
        public virtual ICollection<CompteurEau> Compteurs { get; set; }
        public int AssociationID { get; set; }
        [ForeignKey("AssociationID")]
        public virtual Association Association { get; set; }

    }
}
