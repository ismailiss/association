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
        [Display(Name = "Prénom")]

        public string Prenom { get; set; }
        [Display(Name = "Citoyen")]
        public string NomPrenom {
            get {
                return Nom + " " + Prenom; }
        }
      //  [Display(Name = "النسب")]
            public string NomAr { get; set; }
       // [Display(Name = "الاسم")]
        
        public string PrenomAr { get; set; }
        [Display(Name = "المواطن")]
        public string NomPrenomAr
        {
            get
            {
                return NomAr + " " + PrenomAr;
            }
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
