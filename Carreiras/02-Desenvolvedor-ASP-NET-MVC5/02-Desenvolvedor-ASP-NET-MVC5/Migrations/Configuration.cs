namespace _02_Desenvolvedor_ASP_NET_MVC5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_02_Desenvolvedor_ASP_NET_MVC5.DAO.EstoqueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_02_Desenvolvedor_ASP_NET_MVC5.DAO.EstoqueContext";
        }

        protected override void Seed(_02_Desenvolvedor_ASP_NET_MVC5.DAO.EstoqueContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
