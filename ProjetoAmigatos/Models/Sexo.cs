using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAmigatos.Models {
    public class Sexo {
        [Key]
        public int SexoID { get; set; }

        [Display(Name = "Sexo")]
        public String Nome { get; set; }

        public virtual ICollection<Gato> Gatos { get; set; }
    }
}