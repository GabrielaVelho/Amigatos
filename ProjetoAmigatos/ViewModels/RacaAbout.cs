using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAmigatos.ViewModels {
    public class RacaAbout {
           
            [Display(Name = "Raça")]
            public String NomeRaca { get; set; }

            [Display(Name = "Quantidade de animais no site")]
            public int Qtd { get; set; }

            [Display(Name = "Total de adoções")]
            public int TotalAdocoes { get; set; }

            [Display(Name = "Sexo Masculino")]
            public int numMasculino { get; set; }

            [Display(Name = "Sexo Feminino")]
            public int numFeminino { get; set; }
    }
}