using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAmigatos.Models {
    public class Gato {
        [Key]
        public int GatoID { get; set; }

        [Required]
        [Display(Name = "Nome do Gato")]
        public String Nome { get; set; }
        [Required]
        public int Idade { get; set; }

        [Display(Name = "Raça")]
        public int RacaID { get; set; }
        public virtual Raca Raca { get; set; }

        [Display(Name = "Sexo")]
        public int SexoID { get; set; }
        public virtual Sexo Sexo { get; set; }
       
        [Display(Name = "Image link")]
        [DataType(DataType.ImageUrl)]
        public String ImageUrl { get; set; }

        [Display(Name = "Upload image")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        //Eu tenho que arranjar um jeito de 
        //ligar o user que adotou x gato, mas
        //mas sem que seja obrigatório que o admin cadastre um gato 
        //que já possua um dono

        //Como referenciar o application user?
        //public virtual ApplicationUser UserName { get; set; }

        [Display(Name = "Usuário")]
        public string User { get; set; }
    }
}