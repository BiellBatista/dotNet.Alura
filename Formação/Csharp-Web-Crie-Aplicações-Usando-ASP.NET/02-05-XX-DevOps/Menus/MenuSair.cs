using _02_05_XX_DevOps.Shared.Dados.Banco;
using _02_05_XX_DevOps.Shared.Modelos.Modelos;

namespace _02_05_XX_DevOps.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}