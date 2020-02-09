using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class FacturesGeneree
    {

        [Key]
        public int FacturesGenereeID { get; set; }

        [Display(Name = "Date Factures")]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public DateTime DateFactures { get; set; }

        [Display(Name = "Date Génération")]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public DateTime DateGeneration { get; set; }

    
        [Display(Name = "Mois")]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FactureDe { get; set; }

        [Display(Name = "Nombre Factures Générées")]
        public int? NombreFacturesGenerees {
            get {
                if (Factures == null) return 0;
           else
                return Factures.Count(); } 
                
                  }
    
        public int AssociationID { get; set; }
        [ForeignKey("AssociationID")]
        public virtual Association Association { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }
    }
}
