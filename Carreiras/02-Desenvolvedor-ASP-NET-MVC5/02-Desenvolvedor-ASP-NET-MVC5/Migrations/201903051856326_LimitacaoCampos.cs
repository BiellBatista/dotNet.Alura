namespace _02_Desenvolvedor_ASP_NET_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LimitacaoCampos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "Nome", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Nome", c => c.String());
        }
    }
}
