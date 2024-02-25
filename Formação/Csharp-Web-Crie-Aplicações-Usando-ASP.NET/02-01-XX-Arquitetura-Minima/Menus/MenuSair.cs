using _02_01_XX_Arquitetura_Minima_Shared_Dados.Banco;
using _02_01_XX_Arquitetura_Minima_Shared_Modelos.Modelos;

namespace _02_01_XX_Arquitetura_Minima.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}