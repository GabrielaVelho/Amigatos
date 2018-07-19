namespace ProjetoAmigatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NomeCompleto", c => c.String());
            AddColumn("dbo.AspNetUsers", "Endereco", c => c.String());
            AddColumn("dbo.AspNetUsers", "Cidade", c => c.String());
            AddColumn("dbo.AspNetUsers", "QtdAnimais", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "QtdAnimais");
            DropColumn("dbo.AspNetUsers", "Cidade");
            DropColumn("dbo.AspNetUsers", "Endereco");
            DropColumn("dbo.AspNetUsers", "NomeCompleto");
        }
    }
}
