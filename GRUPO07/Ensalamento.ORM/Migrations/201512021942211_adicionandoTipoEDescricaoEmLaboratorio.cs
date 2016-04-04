namespace Ensalamento.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandoTipoEDescricaoEmLaboratorio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laboratorio", "Tipo", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Laboratorio", "Descricao", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Laboratorio", "Descricao");
            DropColumn("dbo.Laboratorio", "Tipo");
        }
    }
}
