using _01_03_XX_Generics.Banco;
using _01_03_XX_Generics.Modelos;

namespace _01_03_XX_Generics.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}