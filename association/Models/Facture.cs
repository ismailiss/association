using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace association.Models
{
    public class Facture
    {

        [Key]
        public int FactureID { get; set; }

        [Display(Name = "Date Facture")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateFacture { get; set; }

        [Display(Name = "Mois")]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]

        public DateTime FactureDe { get; set; } 

        [Display(Name = "Valeur Compteur")]
        public int ValeurCompteur { get; set; }

        [Display(Name = "Valeur Précédente ")]
        public int ValeurCompteurPrecedente { get; set; }

        [Display(Name = "Consomation (Litre)")]
        public int Consomation {
           get
            {
                return ValeurCompteur - ValeurCompteurPrecedente;
            }
        }
        [DisplayFormat( DataFormatString = "{0:N2}")]
        public float Montant {
            get
            {
                if (Tarif != null)
                    return (float)Consomation * Tarif.Montant / 1000;
                else return 0;
            }
        }

        [Display(Name = "Payée ?")]
        public bool isPayee { get; set; }

        public int CompteurEauID { get; set; }
        [ForeignKey("CompteurEauID")]
        public virtual CompteurEau CompteurEau { get; set; }

        public int? TarifID { get; set; }
        [ForeignKey("TarifID")]
        public virtual Tarif Tarif { get; set; }

        public int? FacturesGenereeID { get; set; }
        [ForeignKey("FacturesGenereeID")]
        public virtual FacturesGeneree FacturesGeneree { get; set; }

    }
    
}
