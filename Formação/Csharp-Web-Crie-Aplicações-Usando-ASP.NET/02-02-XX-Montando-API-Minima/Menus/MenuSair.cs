using _02_02_XX_Montando_API_Minima.Shared.Dados.Banco;
using _02_02_XX_Montando_API_Minima.Shared.Modelos.Modelos;

namespace _02_02_XX_Montando_API_Minima.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}