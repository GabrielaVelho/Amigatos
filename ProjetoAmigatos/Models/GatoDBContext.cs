using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoAmigatos.Models {
    public class GatoDBContext : DbContext {
        public GatoDBContext(): base("GatoDbContext") { }

        public DbSet<Raca> Racas { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<Gato> Gatos { get; set; }

    }
}