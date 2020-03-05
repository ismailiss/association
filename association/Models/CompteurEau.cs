using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class CompteurEau
    {

        [Key]
        public int CompteurEauID { get; set; }

        [Required,StringLength(20)]
        [Display(Name = "Numéro")]
        public string Numero { get; set; }
        public string Emplacement { get; set; }

        [Display(Name = "Date Début")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateDebut { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}" )]
        [Display(Name = "Date Fin")]
        public DateTime? DateFin { get; set; }
        public bool Actif { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        //public int DouarID { get; set; }
        //[ForeignKey("DouarID")]
        //public virtual Douar Douar { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }


    }
}
