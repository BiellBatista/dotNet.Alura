using _01_04_XX_Migrations.Banco;
using _01_04_XX_Migrations.Modelos;

namespace _01_04_XX_Migrations.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}