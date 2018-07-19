using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAmigatos.Models {
    public class Raca {
        [Key]
        public int RacaID { get; set; }

        [Display(Name = "Raça")]
        public String Nome { get; set; }

        public virtual ICollection<Gato> Gatos { get; set; }
    }
}