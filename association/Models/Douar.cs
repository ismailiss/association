using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace association.Models
{
    public class Douar
    {
        [Key]
        public int DouarID { get; set; }
        [StringLength(250)]
        public string LibelleFr { get; set; }
        [Display(Name = "اسم الدوار")]
        [StringLength(250)]
 
        public string LibelleAr { get; set; }
        //public virtual ICollection<CompteurEau> Compteurs { get; set; }
    }
}
