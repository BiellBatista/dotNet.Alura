using _02_01_XX_Arquitetura_Minima.Shared.Dados.Banco;
using _02_01_XX_Arquitetura_Minima.Shared.Modelos.Modelos;

namespace _02_01_XX_Arquitetura_Minima.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}