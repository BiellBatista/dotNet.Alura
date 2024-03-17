using _03_05_XX_Deploy_Azure.Shared.Dados.Banco;
using _03_05_XX_Deploy_Azure.Shared.Modelos.Modelos;

namespace _03_05_XX_Deploy_Azure.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}