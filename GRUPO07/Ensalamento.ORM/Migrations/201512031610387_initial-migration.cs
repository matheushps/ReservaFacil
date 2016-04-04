namespace Ensalamento.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditorio",
                c => new
                    {
                        AuditorioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Capacidade = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        BlocoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuditorioId)
                .ForeignKey("dbo.Bloco", t => t.BlocoId)
                .Index(t => t.BlocoId);
            
            CreateTable(
                "dbo.Bloco",
                c => new
                    {
                        BlocoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Localizacao = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlocoId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Laboratorio",
                c => new
                    {
                        LaboratorioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Capacidade = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        BlocoId = c.Int(nullable: false),
                        Tipo = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.LaboratorioId)
                .ForeignKey("dbo.Bloco", t => t.BlocoId)
                .Index(t => t.BlocoId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFim = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        SalaId = c.Int(nullable: true),
                        LaboratorioId = c.Int(nullable: true),
                        AuditorioId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.Auditorio", t => t.AuditorioId)
                .ForeignKey("dbo.Laboratorio", t => t.LaboratorioId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Sala", t => t.SalaId)
                .Index(t => t.PessoaId)
                .Index(t => t.SalaId)
                .Index(t => t.LaboratorioId)
                .Index(t => t.AuditorioId);
            
            CreateTable(
                "dbo.Sala",
                c => new
                    {
                        SalaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Capacidade = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        BlocoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalaId)
                .ForeignKey("dbo.Bloco", t => t.BlocoId)
                .Index(t => t.BlocoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "SalaId", "dbo.Sala");
            DropForeignKey("dbo.Sala", "BlocoId", "dbo.Bloco");
            DropForeignKey("dbo.Reserva", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Reserva", "LaboratorioId", "dbo.Laboratorio");
            DropForeignKey("dbo.Reserva", "AuditorioId", "dbo.Auditorio");
            DropForeignKey("dbo.Pessoa", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Laboratorio", "BlocoId", "dbo.Bloco");
            DropForeignKey("dbo.Auditorio", "BlocoId", "dbo.Bloco");
            DropIndex("dbo.Sala", new[] { "BlocoId" });
            DropIndex("dbo.Reserva", new[] { "AuditorioId" });
            DropIndex("dbo.Reserva", new[] { "LaboratorioId" });
            DropIndex("dbo.Reserva", new[] { "SalaId" });
            DropIndex("dbo.Reserva", new[] { "PessoaId" });
            DropIndex("dbo.Pessoa", new[] { "CategoriaId" });
            DropIndex("dbo.Laboratorio", new[] { "BlocoId" });
            DropIndex("dbo.Auditorio", new[] { "BlocoId" });
            DropTable("dbo.Sala");
            DropTable("dbo.Reserva");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Laboratorio");
            DropTable("dbo.Categoria");
            DropTable("dbo.Bloco");
            DropTable("dbo.Auditorio");
        }
    }
}
