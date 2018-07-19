using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjetoAmigatos.Models {
    public class GatoInitializer : System.Data.Entity.DropCreateDatabaseAlways<GatoDBContext> {
        protected override void Seed(GatoDBContext context) {
                var sexos = new List<Sexo> {
                new Sexo { Nome = "Feminino" },
                new Sexo { Nome = "Masculino" }
            };

            sexos.ForEach(a => context.Sexos.Add(a));
            context.SaveChanges();


            var racas = new List<Raca> {
                new Raca { Nome = "Ragdoll" },
                new Raca { Nome = "Chausie" },
                new Raca { Nome = "Ocicat" },
                new Raca { Nome = "Sphynx" },
                new Raca { Nome = "Snowshoe" },
                new Raca { Nome = "Persa" },
                new Raca { Nome = "Chartreux" },
                new Raca { Nome = "Curl Americano" },
                new Raca { Nome = "Vira-Lata" },
                new Raca { Nome = "Cornish Rex" },
                new Raca { Nome = "Siamês" },
                new Raca { Nome = "Maine Coon" },
                new Raca { Nome = "Scottish Fold" },
                new Raca { Nome = "Bobtail" }
            };

            racas.ForEach(r => context.Racas.Add(r));
            context.SaveChanges();

            var gatos = new List<Gato> {
                new Gato {
                    Nome = "Bolinha",
                    Idade = 2,
                    SexoID = sexos.Single(a => a.Nome == "Feminino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Vira-Lata").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Bolinha.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Flocos",
                    Idade = 7,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Siamês").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Flocos.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Simba",
                    Idade = 1,
                    SexoID = sexos.Single(a => a.Nome == "Feminino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Persa").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Simba.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Luna",
                    Idade = 4,
                    SexoID = sexos.Single(a => a.Nome == "Feminino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Ragdoll").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Luna.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Pamonha",
                    Idade = 5,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Sphynx").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Pamonha.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Nescau",
                    Idade = 8,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Siamês").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Nescau.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Tiger",
                    Idade = 1,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Ocicat").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Tiger.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Mesclada",
                    Idade = 4,
                    SexoID = sexos.Single(a => a.Nome == "Feminino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Snowshoe").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Mesclada.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Feijão",
                    Idade = 9,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Vira-Lata").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Feijao.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Peludinho",
                    Idade = 5,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Vira-Lata").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Peludinho.jpg"),
                    ImageMimeType = "image/jpeg"
                },
                new Gato {
                    Nome = "Bills",
                    Idade = 11,
                    SexoID = sexos.Single(a => a.Nome == "Masculino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Cornish Rex").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Bills.jpg"),
                    ImageMimeType = "image/jpeg"
                },
               new Gato {
                    Nome = "Fumaça",
                    Idade = 9,
                    SexoID = sexos.Single(a => a.Nome == "Feminino").SexoID,
                    RacaID = racas.Single(s => s.Nome == "Chartreux").RacaID,
                    ImageFile = loadImage("\\Images\\Gatos\\Fumaca.jpg"),
                    ImageMimeType = "image/jpeg"
                },
            };

            gatos.ForEach(g => context.Gatos.Add(g));
            context.SaveChanges();
        }

        private byte[] loadImage(string path) {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk)) {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}