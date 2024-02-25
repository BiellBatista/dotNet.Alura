using _01_05_XX_Relacionamento.Banco;
using _01_05_XX_Relacionamento.Modelos;

namespace _01_05_XX_Relacionamento.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}