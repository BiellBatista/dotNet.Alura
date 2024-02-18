using _01_02_XX_Bibliotecas_ORM.Banco;

namespace _01_02_XX_Bibliotecas_ORM.Menus;

internal class MenuSair : Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}