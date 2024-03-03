using _03_01_XX_Web_App_Blazor.Shared.Dados.Banco;
using _03_01_XX_Web_App_Blazor.Shared.Modelos.Modelos;

namespace _03_01_XX_Web_App_Blazor.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}