namespace ProjetoAmigatos.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoAmigatos.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProjetoAmigatos.Models.ApplicationDbContext";
        }

        protected override void Seed(ProjetoAmigatos.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate(
                u => u.UserName,
                new ApplicationUser {
                    UserName = "aa@mvc.br",
                    NomeCompleto = "AA",
                    Endereco = "Morango",
                    Cidade = "Porto Alegre",
                    QtdAnimais = 0,
                    PasswordHash = hasher.HashPassword("Pass@word1"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser {
                    UserName = "admin@mvc.br",
                    NomeCompleto = "Administrador",
                    Endereco = "Rua Laranjas, número 325",
                    Cidade = "Porto Alegre", 
                    QtdAnimais = 3,
                    PasswordHash = hasher.HashPassword("Pass@word1"),
                    SecurityStamp = Guid.NewGuid().ToString()
                });
        }
    }
}
