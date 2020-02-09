using association.Models.asso_config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class Tarif
    {
        [Key]
        public int TarifID { get; set; }
        public float Montant { get; set; }
        
        
        public DateTime DateApplication { get; set; }

        public DateTime? DateFinApplication { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }

    }
}
