namespace _02_Desenvolvedor_ASP_NET_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaisLimitacao1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "Preco", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
