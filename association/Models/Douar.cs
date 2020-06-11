using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class Douar
    {
        [Key]
        public int DouarID { get; set; }
        [StringLength(250)]
        public string NomFr { get; set; }
        [Display(Name = "اسم الدوار")]
        [StringLength(250)]
        public string NomAr { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
