using _02_03_XX_Boas_Praticas_Construcao_API.Shared.Dados.Banco;
using _02_03_XX_Boas_Praticas_Construcao_API.Shared.Modelos.Modelos;

namespace _02_03_XX_Boas_Praticas_Construcao_API.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}